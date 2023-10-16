using System.Collections.Generic;

namespace Battle
{
    /// <summary>
    /// 技能基础组件
    /// </summary>
    public class SkillBase : Component
    {
        // 释放目标
        public int Release;
        // 生效目标队列
        public readonly List<int> TargetList = new();
        // 是否激活
        public bool IsActivate;
        // 是否生效
        public bool IsTakeEffect;
        
        // 是否触发完成
        public bool IsTriggerOver;
        // 是否生效完成
        public bool IsTakeOver;
    }
}