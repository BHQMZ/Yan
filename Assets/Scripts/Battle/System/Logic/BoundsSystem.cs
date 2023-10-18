using UnityEngine;

namespace Battle
{
    public class BoundsSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _boxQuery;
        private EntityQuery _ballQuery;
        
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
        }

        public override void Update(int step)
        {
            _ballQuery.GetEntityIdList().ForEach(BallBounds);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_boxQuery.desc);
            _entityManager.RemoveWithComponent(_ballQuery.desc);
        }

        private void BallBounds(int ballEntityId)
        {
            var ball = _entityManager.GetComponent<Ball>(ballEntityId);
            if (ball.Radius <= 0)
            {
                return;
            }

            var bounds = _entityManager.GetComponent<Bounds>(ballEntityId);
            var ballTransform = _entityManager.GetComponent<Transform>(ballEntityId);
            
            bounds.Query.GetEntityIdList().ForEach(entityId =>
            {
                var transform = _entityManager.GetComponent<Transform>(entityId);
                if (Vector3.Distance(new Vector3(transform.Position.x, 0, transform.Position.z), new Vector3(ballTransform.Position.x, 0, ballTransform.Position.z)) <= ball.Radius)
                {
                    if (!bounds.EntityList.Contains(entityId))
                    {
                        bounds.EntityList.Add(entityId);
                    }
                }
                else
                {
                    if (bounds.EntityList.Contains(entityId))
                    {
                        bounds.EntityList.Remove(entityId);
                    }
                }
            });
        }
    }
}