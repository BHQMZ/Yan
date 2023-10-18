using UnityEngine;

namespace Battle
{
    public class PlayerControlSystem : VisualSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerControl), typeof(Transform)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var playerControl = _entityManager.GetComponent<PlayerControl>(entityId);
                var transform = _entityManager.GetComponent<Transform>(entityId);
                var action = _entityManager.GetComponent<Action>(entityId);

                var velocity = Vector3.zero;
                if (Input.GetKey("w"))
                {
                    velocity += Vector3.forward;
                }

                if (Input.GetKey("s"))
                {
                    velocity += Vector3.back;
                }

                if (Input.GetKey("a"))
                {
                    velocity += Vector3.left;
                }

                if (Input.GetKey("d"))
                {
                    velocity += Vector3.right;
                }

                if (velocity != Vector3.zero)
                {
                    velocity = velocity.normalized;
                    action.MoveState = MoveStateEnum.Walk;
                }
                else
                {
                    action.MoveState = MoveStateEnum.Null;
                }

                if (playerControl.Velocity != velocity)
                {
                    transform.Velocity -= playerControl.Velocity - velocity;
                    if (velocity.x > 0)
                    {
                        transform.IsRight = true;
                    }
                    else if (velocity.x < 0)
                    {
                        transform.IsRight = false;
                    }
                    playerControl.Velocity = velocity;
                }

                if (Input.GetKey("f"))
                {
                    var releaseSkillControl = _entityManager.GetComponent<ReleaseSkillControl>(entityId);
                    if (releaseSkillControl.CurSkillData.Skill <= 0)
                    {
                        releaseSkillControl.TriggerSkillIndex = 1;
                    }
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}