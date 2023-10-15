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
                All = new []{typeof(MonsterControl), typeof(Transform)}
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
                    _playerQuery.GetEntityIdList().ForEach(entityId =>
                    {
                        var playerTransform = _entityManager.GetComponent<Transform>(entityId);
                        var newDistance = Vector3.Distance(playerTransform.Position, transform.Position);
                        if (targetId == 0 || targetDistance > newDistance)
                        {
                            targetDistance = newDistance;
                            targetId = entityId;
                        }
                    });
                    if (targetId == 0)
                    {
                        return;
                    }
                    monsterControl.TargetId = targetId;
                }

                var playerTransform = _entityManager.GetComponent<Transform>(monsterControl.TargetId);
                var distance = Vector3.Distance(playerTransform.Position, transform.Position);
                var action = _entityManager.GetComponent<Action>(entityId);
                if (distance > 10)
                {
                    action.MoveState = MoveStateEnum.Walk;
                    transform.Velocity = (playerTransform.Position - transform.Position).normalized * 0.5f;
                    if (transform.Velocity.x > 0)
                    {
                        transform.IsRight = true;
                    }
                    else if (transform.Velocity.x < 0)
                    {
                        transform.IsRight = false;
                    }
                }
                else
                {
                    action.MoveState = MoveStateEnum.Null;
                    if (action.CurAttack.Attack == AttackActionEnum.Null)
                    {
                        action.TriggerAttack = AttackActionEnum.Attack;
                    }
                    transform.Velocity = Vector3.zero;
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}