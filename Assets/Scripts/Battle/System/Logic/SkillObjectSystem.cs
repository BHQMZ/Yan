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
                All = new []{typeof(SkillObject), typeof(Transform)}
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