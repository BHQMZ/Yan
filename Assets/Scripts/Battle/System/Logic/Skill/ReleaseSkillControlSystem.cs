
using Battle.Condition;

namespace Battle
{
    public class ReleaseSkillControlSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        private int _step;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(ReleaseSkillControl)}
            });
        }

        public override void Update(int step)
        {
            _step = step;
            _entityQuery.GetEntityIdList().ForEach(ReleaseSkill);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }

        private void ReleaseSkill(int entityId)
        {
            var skillControl = _entityManager.GetComponent<ReleaseSkillControl>(entityId);
            if (skillControl.CurSkillData.Skill == 0 && skillControl.TriggerSkillIndex > 0)
            {
                if (skillControl.TriggerSkillIndex <= skillControl.SkillList.Length)
                {
                    var skillData = skillControl.SkillList[skillControl.TriggerSkillIndex - 1];
                    var release = _entityManager.GetComponent<Release>(skillData.Skill);
                    if (release != null)
                    {
                        var skillBase = _entityManager.GetComponent<SkillBase>(skillData.Skill);
                        skillBase.Release = entityId;
                        skillBase.TargetList.Add(skillControl.Target);
                        
                        release.IsRelease = true;
                        skillControl.CurSkillData = skillData;
                        skillControl.TriggerSkillStep = _step;
                    }
                }
                skillControl.TriggerSkillIndex = 0;
            }

            if (skillControl.CurSkillData.Skill == 0)
            {
                return;
            }

            if (skillControl.TriggerSkillStep == _step)
            {
                // 当前帧设置的触发，不做逻辑处理
                return;
            }

            var skill = _entityManager.GetComponent<SkillBase>(skillControl.CurSkillData.Skill);
            if (!skill.IsActivate)
            {
                skillControl.CurSkillData = default;
            }
        }
    }
}