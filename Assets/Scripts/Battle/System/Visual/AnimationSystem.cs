
namespace Battle
{
    public class AnimationSystem : VisualSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Action), typeof(Character)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var character = _entityManager.GetComponent<Character>(entityId);
                if (!character.transform || !character.animator)
                {
                    return;
                }
                var action = _entityManager.GetComponent<Action>(entityId);
                character.animator.CrossFade(action.CurData.Name, 0, -1, action.CurFrame * 1f / action.CurData.Frame);
            });
        }

        public override void Destroy()
        {
        }
    }
}