
using UnityEngine;

namespace Battle
{
    public class MoveControlSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(MoveControl)}
            });
        }

        public override void Update(int step)
        {
            _entityQuery.GetEntityIdList().ForEach(UpdateMoveControl);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }

        private void UpdateMoveControl(int entityId)
        {
            var moveControl = _entityManager.GetComponent<MoveControl>(entityId);
            var transform = _entityManager.GetComponent<Transform>(moveControl.Target);
            if (transform == null)
            {
                // 没有目标，或者目标没有Transform组件，直接销毁
                _entityManager.DestroyEntity(entityId);
                return;
            }
            transform.Velocity -= moveControl.Velocity;
            if (moveControl.CurTime >= moveControl.Time)
            {
                // 完成控制直接销毁
                _entityManager.DestroyEntity(entityId);
                return;
            }
            
            var velocity = moveControl.Speed * moveControl.Direction;
            
            transform.Velocity += velocity;
            
            moveControl.Velocity = velocity;

            moveControl.CurTime++;
        }
    }
}