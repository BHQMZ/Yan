using System.Collections.Generic;

namespace Battle
{
    public class AnimatorControl : Component
    {
        public static readonly Dictionary<AttackActionEnum, string> AttackActionMap = new()
        {
            [AttackActionEnum.Attack] = "Attack"
        };

        // 上一次触发攻击动作帧
        public int LastAttackStep;

        public MoveStateEnum MoveState;
    }
}