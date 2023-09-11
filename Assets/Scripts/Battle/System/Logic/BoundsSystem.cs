namespace Battle
{
    public class BoundsSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _boxQuery;
        private EntityQuery _ballQuery;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _boxQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Box), typeof(Bounds), typeof(Transform)}
            });

            _ballQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Ball), typeof(Bounds), typeof(Transform)}
            });
            
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Transform)}
            });
        }

        public override void Update()
        {
            _ballQuery.GetEntityList().ForEach(entity =>
            {
                var ball = _entityManager.GetComponent<Ball>(entity);
                if (ball.radius <= 0)
                {
                    return;
                }

                var bounds = _entityManager.GetComponent<Bounds>(entity);
                var transform = _entityManager.GetComponent<Transform>(entity);
                _entityQuery.GetEntityList().ForEach(e =>
                {
                    
                });
            });
        }

        public override void Destroy()
        {
        }
    }
}