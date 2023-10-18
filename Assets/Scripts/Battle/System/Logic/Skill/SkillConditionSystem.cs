using Battle.Condition;

namespace Battle
{
    public class SkillConditionSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _releaseQuery;
        private EntityQuery _durationQuery;
        private EntityQuery _countQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _releaseQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(Release)}
            });
            _durationQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(Duration)}
            });
            _countQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(Count)}
            });
        }

        public override void Update(int step)
        {
            _releaseQuery.GetEntityIdList().ForEach(ReleaseActivate);
            _durationQuery.GetEntityIdList().ForEach(DurationActivate);
            _countQuery.GetEntityIdList().ForEach(CountActivate);
            _entityManager.UpdateWithComponent();
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_releaseQuery.desc);
            _entityManager.RemoveWithComponent(_durationQuery.desc);
            _entityManager.RemoveWithComponent(_countQuery.desc);
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

        private void DurationActivate(int entityId)
        {
            var duration = _entityManager.GetComponent<Duration>(entityId);
            if (duration.CurTime >= duration.Time)
            {
                _entityManager.DestroyEntity(entityId);
                return;
            }

            duration.CurTime++;

            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (!skillBase.IsActivate)
            {
                // 已经激活不做处理
                return;
            }
            
            // 每次重置目标
            skillBase.TargetList.Clear();
            // 激活
            ActivateSkill(skillBase);
        }
        
        private void CountActivate(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (skillBase.IsActivate)
            {
                // 已经激活不做处理
                return;
            }
            
            var duration = _entityManager.GetComponent<Count>(entityId);
            if (duration.CurActivateCount >= duration.ActivateCount)
            {
                _entityManager.DestroyEntity(entityId);
                return;
            }

            // 每次重置目标
            skillBase.TargetList.Clear();
            // 激活
            ActivateSkill(skillBase);

            duration.CurActivateCount++;
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