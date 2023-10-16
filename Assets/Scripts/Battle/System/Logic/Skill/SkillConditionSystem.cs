using Battle.Condition;

namespace Battle
{
    public class SkillConditionSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _releaseQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _releaseQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(Release)}
            });
        }

        public override void Update(int step)
        {
            _releaseQuery.GetEntityIdList().ForEach(ReleaseActivate);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_releaseQuery.desc);
        }

        private void ReleaseActivate(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (skillBase.IsActivate)
            {
                // 已经激活不做处理
                return;
            }

            var release = _entityManager.GetComponent<Release>(entityId);
            if (!release.IsRelease)
            {
                // 未释放不做处理
                return;
            }

            release.IsRelease = false;
            ActivateSkill(skillBase);
        }

        private void ActivateSkill(SkillBase skillBase)
        {
            skillBase.IsActivate = true;
            skillBase.IsTakeEffect = false;
            skillBase.IsTriggerOver = false;
            skillBase.IsTakeOver = false;
        }
    }
}