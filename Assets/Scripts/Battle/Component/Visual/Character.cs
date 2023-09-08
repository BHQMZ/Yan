using UnityEngine;

namespace Battle
{
    public class Character : Component
    {
        public UnityEngine.Transform transform;
        public UnityEngine.Transform point;
        public Animator animator;

        public int moveStep;
        public Vector3 stepMoveVelocity;
    }
}