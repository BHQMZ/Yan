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
            _entityQuery.GetEntityList().ForEach(entity =>
            {
                var transform = _entityManager.GetComponent<Transform>(entity);
                _ballQuery.GetEntityList().ForEach(e =>
                {
                    var ball = _entityManager.GetComponent<Ball>(e);
                    if (ball.radius <= 0)
                    {
                        return;
                    }

                    var bounds = _entityManager.GetComponent<Bounds>(e);
                    var ballTransform = _entityManager.GetComponent<Transform>(e);
                    if (Vector3.Distance(transform.position, ballTransform.position) <= ball.radius)
                    {
                        if (!bounds.entityList.Contains(entity.entityId))
                        {
                            bounds.entityList.Add(entity.entityId);
                        }
                    }
                    else
                    {
                        if (bounds.entityList.Contains(entity.entityId))
                        {
                            bounds.entityList.Remove(entity.entityId);
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