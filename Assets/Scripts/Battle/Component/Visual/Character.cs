using UnityEngine;

namespace Battle
{
    public class Character : Component
    {
        public UnityEngine.Transform Transform;
        public UnityEngine.Transform Point;
        public Animator Animator;

        public bool IsSync;
        public int MoveStep;
        public Vector3 StepMoveVelocity;
    }
}