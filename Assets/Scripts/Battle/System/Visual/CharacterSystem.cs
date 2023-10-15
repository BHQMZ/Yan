
using System;
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
                if (!character.Transform)
                {
                    return;
                }

                var transform = _entityManager.GetComponent<Transform>(entityId);
                // // 逻辑位置转表现位置
                if (transform.Velocity != Vector3.zero)
                {
                    if (character.MoveStep != step)
                    {
                        character.MoveStep = step;
                        var stepStartPos = character.Transform.position;
                        var stepEndPos = transform.Position;
                        character.StepMoveVelocity = (stepEndPos - stepStartPos).normalized * Vector3.Distance(stepStartPos, stepEndPos) / 0.033f;
                    }

                    character.Transform.position += character.StepMoveVelocity * deltaTime;
                }
                else
                {
                    character.StepMoveVelocity = Vector3.zero;
                    character.Transform.position = transform.Position;
                }

                if (transform.IsRight)
                {
                    character.Transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    character.Transform.localScale = new Vector3(1, 1, 1);
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}