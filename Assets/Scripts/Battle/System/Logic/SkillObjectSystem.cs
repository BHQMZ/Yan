namespace Battle
{
    public class SkillObjectSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillObject), typeof(Bounds), typeof(Transform)}
            });
        }

        public override void Update()
        {
            // 触发技能
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var bounds = _entityManager.GetComponent<Bounds>(entityId);
                if (bounds.entityList.Count <= 0)
                {
                    return;
                }

                var skillObject = _entityManager.GetComponent<SkillObject>(entityId);
                var skillBase =_entityManager.GetComponent<SkillBase>(skillObject.skillEntityId);
                bounds.entityList.ForEach(id =>
                {
                    if (!skillBase.targetList.Contains(id))
                    {
                        skillBase.targetList.Add(id);
                    }
                });
            });

            // 移动物体
        }

        public override void Destroy()
        {
        }
    }
}