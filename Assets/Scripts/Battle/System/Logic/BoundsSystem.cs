using System;
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
        
        private EntityQuery _boundsBoxQuery;
        private EntityQuery _boxQuery;
        private List<int> _boxList;
        
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
            
            _boundsBoxQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Bounds), typeof(Box), typeof(Transform)}
            });

            _boxQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Box), typeof(Transform)}
            });
        }

        public override void Update(int step)
        {
            _ballList = _ballQuery.GetEntityIdList();
            _boxList = _boxQuery.GetEntityIdList();
            _boundsBallQuery.GetEntityIdList().ForEach(UpdateBoundsBall);
            _boundsBoxQuery.GetEntityIdList().ForEach(UpdateBoundsBox);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_boundsBallQuery.desc);
            _entityManager.RemoveWithComponent(_ballQuery.desc);
            _entityManager.RemoveWithComponent(_boundsBoxQuery.desc);
            _entityManager.RemoveWithComponent(_boxQuery.desc);
        }

        private void UpdateBoundsBall(int entityId)
        {
            // 球和球
            CheckBounds(entityId, _ballList, CheckBallAndBall);
            // 球和框
            CheckBounds(entityId, _boxList, CheckBallAndBox);
        }
        
        private void UpdateBoundsBox(int entityId)
        {
            // 框和框
            CheckBounds(entityId, _boxList, CheckBoxAndBox);
            // 框和球
            CheckBounds(entityId, _ballList, CheckBoxAndBall);
        }

        private void CheckBounds(int entityId, List<int> checkList, Func<int, int, bool> checkFun)
        {
            var bounds = _entityManager.GetComponent<Bounds>(entityId);

            bounds.Query.UpdateEntityList(_entityManager, checkList);
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
                if (checkFun(entityId, checkEntityId))
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
        /// 球和球的碰撞检测
        /// </summary>
        private bool CheckBallAndBall(int aEntityId, int bEntityId)
        {
            var aBall = _entityManager.GetComponent<Ball>(aEntityId);
            var aTransform = _entityManager.GetComponent<Transform>(aEntityId);
            
            var bBall = _entityManager.GetComponent<Ball>(bEntityId);
            var bTransform = _entityManager.GetComponent<Transform>(bEntityId);
            
            var aPos = aTransform.Position + aBall.Offset;
            var bPos = bTransform.Position + bBall.Offset;

            return (aPos.x - bPos.x) * (aPos.x - bPos.x) + (aPos.y - bPos.y) * (aPos.y - bPos.y) +
                (aPos.z - bPos.z) * (aPos.z - bPos.z) <= (aBall.Radius + bBall.Radius) * (aBall.Radius + bBall.Radius);
        }
        
        /// <summary>
        /// 球和矩形的碰撞检测
        /// </summary>
        private bool CheckBallAndBox(int aEntityId, int bEntityId)
        {
            var aBall = _entityManager.GetComponent<Ball>(aEntityId);
            var aTransform = _entityManager.GetComponent<Transform>(aEntityId);
            
            var bBox = _entityManager.GetComponent<Box>(bEntityId);
            var bTransform = _entityManager.GetComponent<Transform>(bEntityId);
            
            var ballPos = aTransform.Position + aBall.Offset;
            var boxPos = bTransform.Position + bBox.Offset;

            var pos = new Vector3(Mathf.Clamp(boxPos.x - bBox.X / 2, boxPos.x + bBox.X / 2, ballPos.x)
                , Mathf.Clamp(boxPos.y - bBox.Y / 2, boxPos.y + bBox.Y / 2, ballPos.y)
                , Mathf.Clamp(boxPos.z - bBox.Z / 2, boxPos.z + bBox.Z / 2, ballPos.z));

            return (pos.x - ballPos.x) * (pos.x - ballPos.x) + (pos.y - ballPos.y) * (pos.y - ballPos.y) +
                (pos.z - ballPos.z) * (pos.z - ballPos.z) <= aBall.Radius * aBall.Radius;
        }
        
        /// <summary>
        /// 矩形和矩形的碰撞检测
        /// </summary>
        private bool CheckBoxAndBox(int aEntityId, int bEntityId)
        {
            var aBox = _entityManager.GetComponent<Box>(aEntityId);
            var aTransform = _entityManager.GetComponent<Transform>(aEntityId);

            var bBox = _entityManager.GetComponent<Box>(bEntityId);
            var bTransform = _entityManager.GetComponent<Transform>(bEntityId);

            var aPos = aTransform.Position + aBox.Offset;
            var bPos = bTransform.Position + bBox.Offset;

            return aPos.x - aBox.X / 2 <= bPos.x + bBox.X / 2 && aPos.x + aBox.X / 2 <= bPos.x - bBox.X / 2
                && aPos.y - aBox.Y / 2 <= bPos.y + bBox.Y / 2 && aPos.y + aBox.Y / 2 <= bPos.y - bBox.Y / 2
                && aPos.z - aBox.Z / 2 <= bPos.z + bBox.Z / 2 && aPos.z + aBox.Z / 2 <= bPos.z - bBox.Z / 2;
        }
        
        /// <summary>
        /// 矩形和球的碰撞检测
        /// </summary>
        private bool CheckBoxAndBall(int aEntityId, int bEntityId)
        {
            return CheckBallAndBox(bEntityId, aEntityId);
        }
    }
}