
namespace Battle
{
    public class ActionSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Action)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var action = _entityManager.GetComponent<Action>(entityId);

                action.curFrame++;
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}