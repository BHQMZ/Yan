using UnityEngine;

namespace Battle
{
    public class MoveControl : Component
    {
        // 移动方向
        public Vector3 Direction;
        // 移动速度（每帧）
        public float Speed;
        // 移动时间（帧）
        public int Time;
        // 当前移动时间（帧）
        public float CurTime;
        // 当前作用力
        public Vector3 Velocity { get; set; }
        // 结束销毁实体
        public bool IsDestroyEntity;
    }
}