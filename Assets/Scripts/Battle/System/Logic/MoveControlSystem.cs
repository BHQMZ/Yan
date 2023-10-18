
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
                All = new []{typeof(MoveControl), typeof(Transform)}
            });
        }

        public override void Update(int step)
        {
            _entityQuery.GetEntityIdList().ForEach(UpdateMoveControl);
            _entityManager.UpdateWithComponent();
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }

        private void UpdateMoveControl(int entityId)
        {
            var moveControl = _entityManager.GetComponent<MoveControl>(entityId);
            var transform = _entityManager.GetComponent<Transform>(entityId);
            transform.Velocity -= moveControl.Velocity;
            if (moveControl.CurTime >= moveControl.Time)
            {
                if (moveControl.IsDestroyEntity)
                {
                    _entityManager.DestroyEntity(entityId);
                }
                else
                {
                    _entityManager.RemoveComponent<MoveControl>(entityId);
                }
                return;
            }
            
            var velocity = moveControl.Speed * moveControl.Direction;
            
            transform.Velocity += velocity;
            
            moveControl.Velocity = velocity;

            moveControl.CurTime++;
        }
    }
}