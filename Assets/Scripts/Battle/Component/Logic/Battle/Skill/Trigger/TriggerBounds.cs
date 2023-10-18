using System.Collections.Generic;

namespace Battle.Trigger
{
    public class TriggerBounds : Component
    {
        // 生效目标数
        public int TargetCount;
        // 是否有目标才触发
        public bool IsHaveTargetTrigger;
    }
}