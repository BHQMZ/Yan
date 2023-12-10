using UnityEngine;

namespace Battle
{
    public class PlayerControlSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerControl), typeof(Transform), typeof(Action)}
            });
        }

        public override void Update(int step)
        {
            _entityQuery.GetEntityIdList().ForEach(UpdatePlayerControl);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }

        private void UpdatePlayerControl(int entityId)
        {
            var playerControl = _entityManager.GetComponent<PlayerControl>(entityId);
            if (playerControl.OldVelocity == playerControl.Velocity)
            {
                return;
            }
            
            var transform = _entityManager.GetComponent<Transform>(entityId);
            var action = _entityManager.GetComponent<Action>(entityId);

            if (playerControl.Velocity != Vector3.zero)
            {
                action.MoveState = MoveStateEnum.Walk;
            }
            else
            {
                action.MoveState = MoveStateEnum.Null;
            }

            if (playerControl.Velocity.x > 0)
            {
                transform.IsRight = true;
            }
            else if (playerControl.Velocity.x < 0)
            {
                transform.IsRight = false;
            }

            transform.Velocity -= playerControl.OldVelocity;
            transform.Velocity += playerControl.Velocity;

            playerControl.OldVelocity = playerControl.Velocity;
        }
    }
}