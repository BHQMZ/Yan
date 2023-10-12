
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
                if (action.ActionName != action.CurData.Name)
                {
                    // 切换当前动作
                    action.CurData = action.ActionDataList.Find(data => data.Name == action.ActionName);
                    action.CurFrame = 0;
                }

                action.CurFrame++;
                if (!action.CurData.IsLoop && action.CurFrame == action.CurData.Frame)
                {
                    // 当前动作播放完毕，切换下一个动作（默认切待机
                    action.ActionName = "Idle";
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}