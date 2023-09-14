using System.Collections.Generic;

namespace Battle
{
    public class SkillEffect : Component
    {
        // 释放目标
        public int release;
        // 生效目标条件
        public EntityQuery targetQuery;
        // 生效目标队列
        public List<int> activateList = new();
        // 执行目标队列
        public List<int> executeList = new();
        // 是否结束
        public bool isOver;
    }
}