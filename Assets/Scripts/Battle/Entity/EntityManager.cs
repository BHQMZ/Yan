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

        private int GetNextEntityId()
        {
            if (_entityIdStack.Count > 0)
            {
                return _entityIdStack.Pop();
            }
            return ++_entityIdIndex;
        }
        
        public int CreateEntity()
        {
            var entityId = GetNextEntityId();
            _entityIds.Add(entityId);
            return entityId;
        }

        public void DestroyEntity(int entityId)
        {
            _entityIds.Remove(entityId);
            if (_entityComponentMap.TryGetValue(entityId, out var value))
            {
                value.Clear();
            }

            _entityIdStack.Push(entityId);
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

        public void RemoveComponent<T>(int entityId) where T : Component
        {
            if (!_entityComponentMap.ContainsKey(entityId))
            {
                return;
            }

            var components = _entityComponentMap[entityId];

            var componentType = typeof(T);

            if (components.ContainsKey(componentType))
            {
                components.Remove(componentType);
            }
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
            foreach (var valuePair in _entityQueryMap)
            {
                valuePair.Value.UpdateEntityList(this);
            }
        }

        public List<int> GetEntityIdAll()
        {
            return _entityIds;
        }
    }
}