using UnityEngine;

namespace Battle
{
    public class MoveSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Transform)}
            });
        }

        public override void Update(int step)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var transform = _entityManager.GetComponent<Transform>(entityId);
                transform.Position += transform.Velocity;
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}