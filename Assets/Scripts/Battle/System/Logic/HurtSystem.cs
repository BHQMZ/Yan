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
                All = new []{typeof(Hurt), typeof(Attribute)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var hurt = _entityManager.GetComponent<Hurt>(entityId);
                var attribute = _entityManager.GetComponent<Attribute>(entityId);
                if (hurt.value == 0)
                {
                    return;
                }

                Debug.Log($"受到{hurt.value}伤害");
                
                attribute.hp -= hurt.value;
                hurt.value = 0;
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}