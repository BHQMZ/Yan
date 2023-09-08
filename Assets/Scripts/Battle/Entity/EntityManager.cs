using System;
using System.Collections.Generic;

namespace Battle
{
    public class EntityManager
    {
        private int _entityIdIndex;
        private readonly Stack<int> _entityIdStack = new();

        private readonly List<Entity> _entitys = new();
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
        
        public Entity CreateEntity()
        {
            var entity = new Entity(GetNextEntityId());
            _entitys.Add(entity);
            return entity;
        }

        public void DestroyEntity(Entity entity)
        {
            _entitys.Remove(entity);
            if (_entityComponentMap.TryGetValue(entity.entityId, out var value))
            {
                value.Clear();
            }

            _entityIdStack.Push(entity.entityId);
        }

        public void AddComponent(Entity entity, Component component)
        {
            if (!_entityComponentMap.ContainsKey(entity.entityId))
            {
                _entityComponentMap[entity.entityId] = new Dictionary<Type, Component>();
            }

            var components = _entityComponentMap[entity.entityId];

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

        public void RemoveComponent<T>(Entity entity) where T : Component
        {
            if (!_entityComponentMap.ContainsKey(entity.entityId))
            {
                return;
            }

            var components = _entityComponentMap[entity.entityId];

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
        
        // 获取指定类型的组件
        public T GetComponent<T>(Entity entity) where T : Component
        {
            return GetComponent<T>(entity.entityId);
        }

        // 检查实体是否包含指定类型的组件
        public bool HasComponent<T>(Entity entity) where T : Component
        {
            var componentType = typeof(T);
            return HasComponent(entity, componentType);
        }
        
        // 检查实体是否包含指定类型的组件
        public bool HasComponent(Entity entity, Type componentType)
        {
            if (!_entityComponentMap.ContainsKey(entity.entityId))
            {
                return false;
            }

            var components = _entityComponentMap[entity.entityId];

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

        public List<Entity> GetEntityAll()
        {
            return _entitys;
        }
    }
}