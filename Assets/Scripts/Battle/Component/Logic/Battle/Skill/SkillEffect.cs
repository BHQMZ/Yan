using System.Collections.Generic;

namespace Battle
{
    public class SkillEffect : Component
    {
        public EntityQuery targetQuery;
        public List<int> activateList;
    }
}