using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class BoundsSystem : System
    {
        private EntityManager _entityManager;

        private EntityQuery _boundsBallQuery;
        private EntityQuery _ballQuery;
        private List<int> _ballList;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;

            _boundsBallQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Bounds), typeof(Ball), typeof(Transform)}
            });

            _ballQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Ball), typeof(Transform)}
            });
        }

        public override void Update(int step)
        {
            _ballList = _ballQuery.GetEntityIdList();
            _boundsBallQuery.GetEntityIdList().ForEach(UpdateBoundsBall);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_boundsBallQuery.desc);
        }

        private void UpdateBoundsBall(int entityId)
        {
            var bounds = _entityManager.GetComponent<Bounds>(entityId);

            bounds.Query.UpdateEntityList(_entityManager, _ballList);
            if (bounds.Query.GetEntityIdList().Count <= 0)
            {
                return;
            }

            bounds.Query.GetEntityIdList().ForEach(checkEntityId =>
            {
                if (entityId == checkEntityId)
                {
                    return;
                }
                if (CheckBallAndBall(entityId, checkEntityId))
                {
                    if (!bounds.EntityList.Contains(checkEntityId))
                    {
                        bounds.EntityList.Add(checkEntityId);
                    }
                }
                else
                {
                    if (bounds.EntityList.Contains(checkEntityId))
                    {
                        bounds.EntityList.Remove(checkEntityId);
                    }
                }
            });
        }

        /// <summary>
        /// 圆和圆的碰撞检测
        /// </summary>
        private bool CheckBallAndBall(int aEntityId, int bEntityId)
        {
            var aBall = _entityManager.GetComponent<Ball>(aEntityId);
            var aTransform = _entityManager.GetComponent<Transform>(aEntityId);
            
            var bBall = _entityManager.GetComponent<Ball>(bEntityId);
            var bTransform = _entityManager.GetComponent<Transform>(bEntityId);

            return Vector3.Distance(aTransform.Position + aBall.Offset, bTransform.Position + bBall.Offset) <= aBall.Radius + bBall.Radius;
        }
    }
}