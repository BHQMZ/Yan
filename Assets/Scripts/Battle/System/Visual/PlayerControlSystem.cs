using UnityEngine;

namespace Battle
{
    public class PlayerControlSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerControl), typeof(Transform)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var playerControl = _entityManager.GetComponent<PlayerControl>(entityId);
                var transform = _entityManager.GetComponent<Transform>(entityId);
                var velocity = Vector3.zero;
                if (Input.GetKey("w"))
                {
                    velocity += Vector3.forward;
                }

                if (Input.GetKey("s"))
                {
                    velocity += Vector3.back;
                }

                if (Input.GetKey("a"))
                {
                    velocity += Vector3.left;
                }

                if (Input.GetKey("d"))
                {
                    velocity += Vector3.right;
                }

                if (velocity != Vector3.zero)
                {
                    velocity = velocity.normalized;
                    var action = _entityManager.GetComponent<Action>(entityId);
                    action.actionName = "Move";
                    action.actionFrame = 36;
                }

                if (playerControl.velocity != velocity)
                {
                    transform.velocity -= playerControl.velocity - velocity;
                    if (velocity.x > 0)
                    {
                        transform.isRight = true;
                    }
                    else if (velocity.x < 0)
                    {
                        transform.isRight = false;
                    }
                    playerControl.velocity = velocity;
                }
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}