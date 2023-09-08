using UnityEngine;

namespace Battle
{
    public class PlayerControl : Component
    {
        private Vector3 _velocity;
        public Vector3 velocity
        {
            get => _velocity;
            set => _velocity = value;
        }
    }
}