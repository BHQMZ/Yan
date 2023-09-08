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
                All = new []{typeof(MonsterControl), typeof(Transform), typeof(Hit)}
            });
            
            _playerQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerControl), typeof(Transform), typeof(Hurt)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityList().ForEach(entity =>
            {
                var monsterControl = _entityManager.GetComponent<MonsterControl>(entity);
                var transform = _entityManager.GetComponent<Transform>(entity);

                if (monsterControl.targetId == 0)
                {
                    var targetDistance = 0f;
                    var targetId = 0;
                    _playerQuery.GetEntityList().ForEach(player =>
                    {
                        var playerTransform = _entityManager.GetComponent<Transform>(player);
                        var newDistance = Vector3.Distance(playerTransform.position, transform.position);
                        if (targetId == 0 || targetDistance > newDistance)
                        {
                            targetDistance = newDistance;
                            targetId = player.entityId;
                        }
                    });
                    if (targetId == 0)
                    {
                        return;
                    }
                    monsterControl.targetId = targetId;
                }

                var playerTransform = _entityManager.GetComponent<Transform>(monsterControl.targetId);
                var distance = Vector3.Distance(playerTransform.position, transform.position);
                var hit = _entityManager.GetComponent<Hit>(entity);
                if (distance > 10)
                {
                    hit.isActivate = false;
                    transform.velocity = (playerTransform.position - transform.position).normalized * 0.5f;
                    if (transform.velocity.x > 0)
                    {
                        transform.isRight = true;
                    }
                    else if (transform.velocity.x < 0)
                    {
                        transform.isRight = false;
                    }
                }
                else
                {
                    transform.velocity = Vector3.zero;
                    hit.targetId = monsterControl.targetId;
                    hit.isActivate = true;
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}