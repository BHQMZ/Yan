using System.Collections.Generic;

namespace Battle
{
    /// <summary>
    /// 技能基础组件
    /// </summary>
    public class SkillBase : Component
    {
        // 释放目标
        public int release;
        // 作用目标队列
        public List<int> targetList;
        // 已生效目标队列
        public List<int> activateList;
    }
}