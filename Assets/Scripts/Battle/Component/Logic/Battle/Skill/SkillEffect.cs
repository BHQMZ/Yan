using System.Collections.Generic;

namespace Battle
{
    public class SkillEffect : Component
    {
        // 释放目标
        public int release;
        public EntityQuery targetQuery;
        public List<int> activateList;
    }
}