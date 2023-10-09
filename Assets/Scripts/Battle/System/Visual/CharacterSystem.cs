
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
                if (!character.transform)
                {
                    return;
                }

                var transform = _entityManager.GetComponent<Transform>(entityId);
                // 逻辑位置转表现位置
                var stepStartPos = character.transform.position;
                var stepEndPos = transform.position;
                if (stepStartPos != stepEndPos)
                {
                    if (character.moveStep != step)
                    {
                        character.moveStep = step;
                        character.stepMoveVelocity = (stepEndPos - stepStartPos).normalized * Vector3.Distance(stepStartPos, stepEndPos) / 0.033f;
                    }

                    var pos = character.transform.position + character.stepMoveVelocity * deltaTime;

                    if (Math.Abs(Vector3.Dot((pos - stepEndPos).normalized, character.stepMoveVelocity.normalized) - 1) < 0.01f)
                    {
                        character.transform.position = pos;
                    }
                    else
                    {
                        character.transform.position = stepEndPos;
                    }
                }

                if (transform.isRight)
                {
                    character.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    character.transform.localScale = new Vector3(1, 1, 1);
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}