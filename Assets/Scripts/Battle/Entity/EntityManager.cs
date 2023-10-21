using System;
using System.Collections.Generic;

namespace Battle
{
    public class EntityManager
    {
        private int _entityIdIndex;
        private readonly Stack<int> _entityIdStack = new();

        private readonly List<int> _entityIds = new();
        private readonly Dictionary<int, Dictionary<Type, Component>> _entityComponentMap = new();
        
        private readonly Dictionary<int, EntityQuery> _entityQueryMap = new();
        private readonly Dictionary<int, int> _entityQueryUseCountMap = new();

        private readonly List<int> _removeEntityIds = new();
        private readonly Dictionary<Type, List<Component>> _removeComponentMap = new();
        private readonly Dictionary<Type, List<Action<Component>>> _removeComponentEvent = new();

        private bool _isUpdateQuery;

        private int GetNextEntityId()
        {
            if (_entityIdStack.Count > 0)
            {
                return _entityIdStack.Pop();
            }
            return ++_entityIdIndex;
        }

        private void ReleaseEntityId(int entityId)
        {
            if (_entityIdStack.Contains(entityId))
            {
                return;
            }
            _entityIdStack.Push(entityId);
        }
        
        public int CreateEntity()
        {
            // 实体变更，需要刷新
            _isUpdateQuery = true;

            var entityId = GetNextEntityId();
            _entityIds.Add(entityId);
            return entityId;
        }

        public void DestroyEntity(int entityId)
        {
            // 实体变更，需要刷新
            _isUpdateQuery = true;

            _entityIds.Remove(entityId);

            // 暂存要销毁的实体
            _removeEntityIds.Add(entityId);
        }

        public void AddComponent(int entityId, Component component)
        {
            if (!_entityComponentMap.ContainsKey(entityId))
            {
                _entityComponentMap[entityId] = new Dictionary<Type, Component>();
            }

            var components = _entityComponentMap[entityId];

            var componentType = component.GetType();

            // 如果实体已经有相同类型的组件，可以选择替换或抛出异常
            if (components.ContainsKey(componentType))
            {
                // 替换组件
                components[componentType] = component;
            }
            else
            {
                // 添加新组件
                components.Add(componentType, component);
            }
        }

        private void RemoveComponent<T>(int entityId) where T : Component
        {
            if (!_entityComponentMap.ContainsKey(entityId))
            {
                return;
            }

            var components = _entityComponentMap[entityId];

            var componentType = typeof(T);

            if (!components.ContainsKey(componentType))
            {
                return;
            }
            AddRemoveComponent(componentType, components[componentType]);
            components.Remove(componentType);
        }

        private void AddRemoveComponent(Type componentType, Component component)
        {
            if (!_removeComponentMap.ContainsKey(componentType))
            {
                _removeComponentMap[componentType] = new List<Component>();
            }
            
            _removeComponentMap[componentType].Add(component);
        }

        // 清除实体关联的全部组件
        private void RemoveEntityComponentAll(int entityId)
        {
            if (!_entityComponentMap.ContainsKey(entityId))
            {
                return;
            }
            
            var components = _entityComponentMap[entityId];
            if (components.Count <= 0)
            {
                return;
            }
            foreach (var keyValuePair in components)
            {
                AddRemoveComponent(keyValuePair.Key, keyValuePair.Value);
            }
            components.Clear();
        }
        
        // 获取指定类型的组件
        public T GetComponent<T>(int entityId) where T : Component
        {
            if (!_entityComponentMap.ContainsKey(entityId))
            {
                return null;
            }

            var components = _entityComponentMap[entityId];

            var componentType = typeof(T);
            if (components.TryGetValue(componentType, out var component))
            {
                return (T)component;
            }
            return null;
        }

        // 检查实体是否包含指定类型的组件
        public bool HasComponent<T>(int entityId) where T : Component
        {
            var componentType = typeof(T);
            return HasComponent(entityId, componentType);
        }
        
        // 检查实体是否包含指定类型的组件
        public bool HasComponent(int entityId, Type componentType)
        {
            if (!_entityComponentMap.ContainsKey(entityId))
            {
                return false;
            }

            var components = _entityComponentMap[entityId];

            return components.ContainsKey(componentType);
        }

        public EntityQuery AddWithComponent(EntityQueryDesc desc)
        {
            var key = desc.GetKey();
            if (_entityQueryMap.TryGetValue(key, out var query))
            {
                _entityQueryUseCountMap[key]++;
                return query;
            }

            var newQuery = new EntityQuery(desc);
            newQuery.UpdateEntityList(this);
            _entityQueryMap[key] = newQuery;
            _entityQueryUseCountMap[key] = 1;
            return newQuery;
        }

        public void RemoveWithComponent(EntityQueryDesc desc)
        {
            var key = desc.GetKey();
            if (!_entityQueryMap.ContainsKey(key))
            {
                return;
            }

            var useCount = _entityQueryUseCountMap[key];
            useCount--;
            if (useCount <= 0)
            {
                _entityQueryMap[key] = null;
                _entityQueryUseCountMap[key] = 0;
            }
            else
            {
                _entityQueryUseCountMap[key] = useCount;
            }
        }

        public void UpdateWithComponent()
        {
            if (!_isUpdateQuery)
            {
                return;
            }
            // 清除已删除实体关联的组件
            if (_removeEntityIds.Count > 0)
            {
                _removeEntityIds.ForEach(RemoveEntityComponentAll);
                _removeEntityIds.Clear();
            }
            // 执行组件销毁相关回调
            foreach (var keyValuePair in _removeComponentMap)
            {
                if (_removeComponentEvent.TryGetValue(keyValuePair.Key, out var value))
                {
                    value.ForEach(action => keyValuePair.Value.ForEach(action.Invoke));
                }
                keyValuePair.Value.Clear();
            }
            // 更新Query
            foreach (var valuePair in _entityQueryMap)
            {
                valuePair.Value.UpdateEntityList(this, _entityIds);
            }
        }

        public List<int> GetEntityIdAll()
        {
            return _entityIds;
        }

        public void AddRemoveComponentEvent<T>(Action<Component> action) where T : Component
        {
            var componentType = typeof(T);
            if (!_removeComponentEvent.ContainsKey(componentType))
            {
                _removeComponentEvent[componentType] = new List<Action<Component>>();
            }
            
            _removeComponentEvent[componentType].Add(action);
        }
    }
}