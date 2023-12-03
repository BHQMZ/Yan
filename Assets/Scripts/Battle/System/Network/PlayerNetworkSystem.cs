namespace Battle
{
    public class PlayerNetworkSystem : NetworkSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerControl), typeof(Transform)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var transform = _entityManager.GetComponent<Transform>(entityId);
                
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}