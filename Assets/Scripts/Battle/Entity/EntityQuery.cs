using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle
{
    public class EntityQuery
    {
        private readonly EntityQueryDesc _desc;
        public EntityQueryDesc desc => _desc;
        
        private List<int> _entityIds;

        public EntityQuery(EntityQueryDesc desc)
        {
            _desc = desc;
            _entityIds = new List<int>();
        }

        public void UpdateEntityList(EntityManager manager)
        {
            UpdateEntityList(manager, manager.GetEntityIdAll());
        }

        public void UpdateEntityList(EntityManager manager, List<int> entityIdList)
        {
            _entityIds = entityIdList.FindAll(entityId => CheckQuery(manager, entityId));
        }

        public bool CheckQuery(EntityManager manager, int entityId)
        {
            if (_desc.All is {Length: > 0})
            {
                if (_desc.All.Any(t => !manager.HasComponent(entityId, t)))
                {
                    return false;
                }
            }

            if (_desc.Any is {Length: > 0})
            {
                if (!_desc.Any.Any(t => manager.HasComponent(entityId, t)))
                {
                    return false;
                }
            }

            if (_desc.None is {Length: > 0})
            {
                if (_desc.None.Any(t => manager.HasComponent(entityId, t)))
                {
                    return false;
                }
            }

            return true;
        }

        public List<int> GetEntityIdList()
        {
            return _entityIds;
        }

        public void AddEntity(EntityManager manager, int entityId)
        {
            if (CheckQuery(manager, entityId))
            {
                _entityIds.Add(entityId);
            }
        }

        public void RemoveEntity(int entityId)
        {
            if (_entityIds.Contains(entityId))
            {
                _entityIds.Remove(entityId);
            }
        }
    }
}