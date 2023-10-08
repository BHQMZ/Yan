namespace Battle
{
    public class SkillEffectSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        private EntityQuery _hitQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillEffect)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var skillEffect = _entityManager.GetComponent<SkillEffect>(entityId);
                skillEffect.activateList.ForEach(targetId =>
                {
                    if (!skillEffect.executeList.Contains(targetId))
                    {
                        skillEffect.executeList.Add(targetId);

                        ExecuteHit(skillEffect.release, targetId);
                    }
                });
            });
        }

        public override void Destroy()
        {
        }

        private void ExecuteHit(int releaseId, int targetId)
        {
            var hit = _entityManager.GetComponent<Hit>(releaseId);

            hit.targetId = targetId;
            hit.isActivate = true;
        }
    }
}