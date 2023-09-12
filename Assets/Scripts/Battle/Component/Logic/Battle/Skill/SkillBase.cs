using System.Collections.Generic;

namespace Battle
{
    /// <summary>
    /// 技能基础组件
    /// </summary>
    public class SkillBase : Component
    {
        // 是否触发
        public bool isTrigger;
        // 是否结束
        public bool isOver;
        // 释放目标
        public int release;
        // 作用目标队列
        public List<int> targetList;
    }
}