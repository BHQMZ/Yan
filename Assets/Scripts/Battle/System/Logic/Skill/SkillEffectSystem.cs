using Battle.Effect;

namespace Battle
{
    public class SkillEffectSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _hitQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _hitQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(Hit), typeof(Attribute)}
            });
        }

        public override void Update(int step)
        {
            _hitQuery.GetEntityIdList().ForEach(TaskEffectHit);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_hitQuery.desc);
        }

        private void TaskEffectHit(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (!skillBase.IsTakeEffect)
            {
                // 技能未生效不做处理
                return;
            }

            var hit = _entityManager.GetComponent<Hit>(entityId);

            skillBase.TargetList.ForEach(target =>
            {
                var hurt = _entityManager.CreateEntity();
                _entityManager.AddComponent(hurt, new Hurt
                {
                    Release = skillBase.Release,
                    Target = target
                });
            });

            hit.IsTaskEffect = true;
        }
    }
}