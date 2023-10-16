
using UnityEngine;

namespace Battle
{
    public class AnimatorControlSystem : VisualSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Action), typeof(Character), typeof(AnimatorControl)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var character = _entityManager.GetComponent<Character>(entityId);
                if (!character.Transform || !character.Animator)
                {
                    return;
                }
                var action = _entityManager.GetComponent<Action>(entityId);
                var animatorControl = _entityManager.GetComponent<AnimatorControl>(entityId);
                if (action.CurAttack.Attack != AttackActionEnum.Null && animatorControl.LastAttackStep != action.TriggerAttackStep)
                {
                    animatorControl.LastAttackStep = action.TriggerAttackStep;
                    character.Animator.SetTrigger(AnimatorControl.AttackActionMap[action.CurAttack.Attack]);
                }

                if (animatorControl.MoveState != action.MoveState)
                {
                    animatorControl.MoveState = action.MoveState;
                    character.Animator.SetInteger("Move", (int) action.MoveState);
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}