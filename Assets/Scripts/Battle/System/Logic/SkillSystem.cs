namespace Battle
{
    public class SkillSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(SkillEffect)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
                if (skillBase.isOver)
                {
                    return;
                }
                if (skillBase.targetList.Count <= 0)
                {
                    return;
                }

                var skillEffect = _entityManager.GetComponent<SkillEffect>(entityId);
                skillEffect.targetQuery.UpdateEntityList(_entityManager, skillBase.targetList);
                var entityIdList = skillEffect.targetQuery.GetEntityIdList();
                if (entityIdList.Count <= 0)
                {
                    return;
                }
                entityIdList.ForEach(id =>
                {
                    if (!skillEffect.activateList.Contains(id))
                    {
                        // 技能对该目标生效
                        skillEffect.activateList.Add(id);
                    }
                });
            });
        }

        public override void Destroy()
        {
        }
    }
}