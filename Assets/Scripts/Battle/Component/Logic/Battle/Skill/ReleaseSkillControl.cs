namespace Battle
{
    public class ReleaseSkillControl : Component
    {
        // 技能目标
        public int Target;
        // 触发技能索引
        public int TriggerSkillIndex;
        // 触发技能帧
        public int TriggerSkillStep;
        // 当前技能
        public ReleaseSkillData CurSkillData;
        // 技能列表
        public ReleaseSkillData[] SkillList;
    }

    public struct ReleaseSkillData
    {
        public int Skill;
    }
}