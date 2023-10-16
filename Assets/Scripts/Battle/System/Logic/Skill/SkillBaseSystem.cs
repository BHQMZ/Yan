
namespace Battle
{
    public class SkillBaseSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase)}
            });
        }

        public override void Update(int step)
        {
            _entityQuery.GetEntityIdList().ForEach(UpdateSkill);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }

        private void UpdateSkill(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (!skillBase.IsActivate)
            {
                // 技能未激活
                return;
            }
            
            if (skillBase.IsTakeOver && skillBase.IsTriggerOver)
            {
                // 技能释放完毕
                SkillOver(skillBase);
            }
        }

        private void SkillOver(SkillBase skillBase)
        {
            skillBase.TargetList.Clear();
            skillBase.IsActivate = false;
            skillBase.IsTakeOver = false;
            skillBase.IsTriggerOver = false;
        }
    }
}