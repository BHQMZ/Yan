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
                All = new []{typeof(SkillBase)}
            });
        }

        public override void Update()
        {
        }

        public override void Destroy()
        {
        }
    }
}