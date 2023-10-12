using UnityEngine;

namespace Battle
{
    public class HurtSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Hurt)}
            });
        }

        public override void Update()
        {
            _entityManager.UpdateWithComponent();
            
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var hurt = _entityManager.GetComponent<Hurt>(entityId);

                // var releaseAttr = _entityManager.GetComponent<Attribute>(hurt.Release);
                var targetAttr = _entityManager.GetComponent<Attribute>(hurt.Target);

                Debug.Log($"受到{hurt.Value}伤害");
                
                targetAttr.hp -= hurt.Value;
                
                _entityManager.DestroyEntity(entityId);
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}