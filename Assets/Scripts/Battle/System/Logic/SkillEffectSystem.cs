namespace Battle
{
    public class SkillEffectSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;

        public override void Init(EntityManager entityManager)
        {
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
                
            });
        }

        public override void Destroy()
        {
        }
    }
}