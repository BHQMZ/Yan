using UnityEngine;

namespace Battle
{
    public class MainPlayerInputSystem : VisualSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(MainPlayer), typeof(PlayerControl)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var playerControl = _entityManager.GetComponent<PlayerControl>(entityId);

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
                }

                if (playerControl.Velocity != velocity)
                {
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