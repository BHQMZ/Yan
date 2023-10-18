using UnityEngine;

namespace Battle
{
    public class MonsterControlSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        private EntityQuery _playerQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(MonsterControl), typeof(Transform), typeof(ReleaseSkillControl)}
            });
            
            _playerQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerControl), typeof(Transform)}
            });
        }

        public override void Update(int step)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var monsterControl = _entityManager.GetComponent<MonsterControl>(entityId);
                var transform = _entityManager.GetComponent<Transform>(entityId);

                if (monsterControl.TargetId == 0)
                {
                    var targetDistance = 0f;
                    var targetId = 0;
                    _playerQuery.GetEntityIdList().ForEach(playerEntityId =>
                    {
                        var playerTransform = _entityManager.GetComponent<Transform>(playerEntityId);
                        var newDistance = Vector3.Distance(playerTransform.Position, transform.Position);
                        if (targetId == 0 || targetDistance > newDistance)
                        {
                            targetDistance = newDistance;
                            targetId = playerEntityId;
                        }
                    });
                    if (targetId == 0)
                    {
                        return;
                    }
                    monsterControl.TargetId = targetId;
                }

                // var playerTransform = _entityManager.GetComponent<Transform>(monsterControl.TargetId);
                var targetPosition = Vector3.zero;
                var distance = Vector3.Distance(targetPosition, transform.Position);
                var action = _entityManager.GetComponent<Action>(entityId);
                var velocity = Vector3.zero;
                if (distance > 1f)
                {
                    action.MoveState = MoveStateEnum.Walk;
                    velocity += (targetPosition - transform.Position).normalized * 0.5f;
                }
                else
                {
                    // if (monsterControl.TargetId > 0)
                    // {
                    //     var releaseSkillControl = _entityManager.GetComponent<ReleaseSkillControl>(entityId);
                    //     releaseSkillControl.Target = monsterControl.TargetId;
                    //     releaseSkillControl.TriggerSkillIndex = 1;
                    // }
                    action.MoveState = MoveStateEnum.Null;
                    velocity = Vector3.zero;
                }
                
                if (monsterControl.Velocity != velocity)
                {
                    transform.Velocity -= monsterControl.Velocity - velocity;
                    if (velocity.x > 0)
                    {
                        transform.IsRight = true;
                    }
                    else if (velocity.x < 0)
                    {
                        transform.IsRight = false;
                    }
                    monsterControl.Velocity = velocity;
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}