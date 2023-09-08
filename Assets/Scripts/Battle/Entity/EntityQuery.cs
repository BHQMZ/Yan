using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle
{
    public class EntityQuery
    {
        private readonly EntityQueryDesc _desc;
        public EntityQueryDesc desc => _desc;
        
        private List<Entity> _entitys;

        public EntityQuery(EntityQueryDesc desc)
        {
            _desc = desc;
            _entitys = new List<Entity>();
        }

        public void UpdateEntityList(EntityManager manager)
        {
            _entitys = manager.GetEntityAll().FindAll(entity => CheckQuery(manager, entity));
        }

        public bool CheckQuery(EntityManager manager, Entity entity)
        {
            if (_desc.All is {Length: > 0})
            {
                if (_desc.All.Any(t => !manager.HasComponent(entity, t)))
                {
                    return false;
                }
            }

            if (_desc.Any is {Length: > 0})
            {
                if (!_desc.Any.Any(t => manager.HasComponent(entity, t)))
                {
                    return false;
                }
            }

            if (_desc.None is {Length: > 0})
            {
                if (_desc.None.Any(t => manager.HasComponent(entity, t)))
                {
                    return false;
                }
            }

            return true;
        }

        public List<Entity> GetEntityList()
        {
            return _entitys;
        }

        public void AddEntity(EntityManager manager, Entity entity)
        {
            if (CheckQuery(manager, entity))
            {
                _entitys.Add(entity);
            }
        }

        public void RemoveEntity(Entity entity)
        {
            if (_entitys.Contains(entity))
            {
                _entitys.Remove(entity);
            }
        }
    }
}