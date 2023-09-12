
using Manager;
using UnityEngine;

namespace Battle
{
    public class CharacterSystem : VisualSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Character), typeof(Transform)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var character = _entityManager.GetComponent<Character>(entityId);
                if (!character.transform)
                {
                    return;
                }

                var transform = _entityManager.GetComponent<Transform>(entityId);
                if (transform.velocity != Vector3.zero)
                {
                    if (character.moveStep != step)
                    {
                        character.moveStep = step;
                        var stepStartPos = character.transform.position;
                        var stepEndPos = transform.position;
                        character.stepMoveVelocity = (stepEndPos - stepStartPos).normalized * Vector3.Distance(stepStartPos, stepEndPos) / 0.033f;
                    }

                    character.transform.position += character.stepMoveVelocity * deltaTime;
                }
                else
                {
                    character.stepMoveVelocity = Vector3.zero;
                    character.transform.position = transform.position;
                }

                if (character.stepMoveVelocity != Vector3.zero)
                {
                    character.animator.SetInteger("Move", 1);
                }
                else
                {
                    character.animator.SetInteger("Move", 0);
                }

                if (transform.isRight)
                {
                    character.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    character.transform.localScale = new Vector3(1, 1, 1);
                }

                if (_entityManager.HasComponent<Hit>(entityId))
                {
                    var hit = _entityManager.GetComponent<Hit>(entityId);
                    if (hit.isActivate)
                    {
                        character.animator.SetInteger("Status", 3);
                    }
                    else
                    {
                        character.animator.SetInteger("Status", 1);
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