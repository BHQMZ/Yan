using System.Collections.Generic;

namespace Battle
{
    public enum AttackActionEnum
    {
        Null,
        // 普通攻击
        Attack
    }

    public enum MoveStateEnum
    {
        // 没有移动
        Null,
        // 行走
        Walk,
        // 奔跑
        Run
    }

    public class Action : Component
    {
        // 移动状态
        public MoveStateEnum MoveState;
        
        // 触发攻击动作
        public AttackActionEnum TriggerAttack;
        // 触发攻击动作帧
        public int TriggerAttackStep;
        // 当前攻击动作
        public AttackActionData CurAttack;
        // 攻击动作数据列表
        public readonly List<AttackActionData> ActionDataList = new();
    }

    public struct AttackActionData
    {
        // 攻击动作
        public AttackActionEnum Attack;
        // 当前帧
        public int CurFrame;
        // 总帧
        public int Frame;
        // 事件帧
        public int EventFrame;
        // 是否循环
        public bool IsLoop;
    }
}