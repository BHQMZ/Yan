
namespace Battle
{
    public class ActionSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Action)}
            });
        }

        public override void Update(int step)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var action = _entityManager.GetComponent<Action>(entityId);
                if (action.TriggerAttack != AttackActionEnum.Null)
                {
                    if (action.TriggerAttack != action.CurAttack.Attack)
                    {
                        action.CurAttack = action.ActionDataList.Find(data => data.Attack == action.TriggerAttack);
                    }
                    action.TriggerAttack = AttackActionEnum.Null;
                    action.TriggerAttackStep = step;
                    action.CurAttack.CurFrame = 0;
                }

                if (action.CurAttack.Attack == AttackActionEnum.Null)
                {
                    return;
                }

                if (!action.CurAttack.IsLoop && action.CurAttack.CurFrame == action.CurAttack.Frame)
                {
                    // 当前动作播放完毕
                    action.CurAttack = default;
                }

                action.CurAttack.CurFrame++;
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}