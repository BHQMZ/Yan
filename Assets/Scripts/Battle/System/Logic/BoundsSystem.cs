using UnityEngine;

namespace Battle
{
    public class BoundsSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _boxQuery;
        private EntityQuery _ballQuery;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _boxQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Box), typeof(Bounds), typeof(Transform)}
            });

            _ballQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Ball), typeof(Bounds), typeof(Transform)}
            });
            
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Transform)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var transform = _entityManager.GetComponent<Transform>(entityId);
                _ballQuery.GetEntityIdList().ForEach(ballEntityId =>
                {
                    var ball = _entityManager.GetComponent<Ball>(ballEntityId);
                    if (ball.radius <= 0)
                    {
                        return;
                    }

                    var bounds = _entityManager.GetComponent<Bounds>(ballEntityId);
                    var ballTransform = _entityManager.GetComponent<Transform>(ballEntityId);
                    if (Vector3.Distance(transform.position, ballTransform.position) <= ball.radius)
                    {
                        if (!bounds.entityList.Contains(entityId))
                        {
                            bounds.entityList.Add(entityId);
                        }
                    }
                    else
                    {
                        if (bounds.entityList.Contains(entityId))
                        {
                            bounds.entityList.Remove(entityId);
                        }
                    }
                });
            });
        }

        public override void Destroy()
        {
        }
    }
}