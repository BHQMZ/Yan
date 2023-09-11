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
            _entityQuery.GetEntityList().ForEach(entity =>
            {
                var bounds = _entityManager.GetComponent<Bounds>(entity);
                if (bounds.entityList.Count <= 0)
                {
                    return;
                }

                var skillObject = _entityManager.GetComponent<SkillObject>(entity);
                var skillBase =_entityManager.GetComponent<SkillBase>(skillObject.skillEntityId);
                bounds.entityList.ForEach(id =>
                {
                    if (!skillBase.activateList.Contains(id))
                    {
                        skillBase.activateList.Add(id);
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