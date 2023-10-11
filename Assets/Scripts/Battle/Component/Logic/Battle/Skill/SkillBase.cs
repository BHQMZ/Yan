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
        // 生效目标队列
        public List<int> targetList = new();
        // 是否激活
        public bool isActivate;
    }
}