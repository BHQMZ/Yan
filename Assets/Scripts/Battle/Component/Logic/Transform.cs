using UnityEngine;

namespace Battle
{
    public class Transform : Component
    {
        private Vector3 _position;
        public Vector3 position
        {
            get => _position;
            set => _position = value;
        }
        
        private Vector3 _forward = Vector3.forward;
        public Vector3 forward
        {
            get => _forward;
            set => _forward = value;
        }
        
        private bool _isRight = false;
        public bool isRight
        {
            get => _isRight;
            set => _isRight = value;
        }

        private Vector3 _velocity;
        public Vector3 velocity
        {
            get => _velocity;
            set => _velocity = value;
        }
    }
}