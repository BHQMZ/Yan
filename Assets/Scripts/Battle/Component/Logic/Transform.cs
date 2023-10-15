using UnityEngine;

namespace Battle
{
    public class Transform : Component
    {
        public Vector3 Position { get; set; }

        public Vector3 Forward { get; set; } = Vector3.forward;

        public bool IsRight { get; set; } = false;

        public Vector3 Velocity { get; set; }
    }
}