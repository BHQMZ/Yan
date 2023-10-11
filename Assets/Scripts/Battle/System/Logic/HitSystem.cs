using UnityEngine;

namespace Battle
{
    public class HitSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Hit), typeof(SkillBase), typeof(Attribute)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
                if (!skillBase.isActivate)
                {
                    return;
                }

                var hit = _entityManager.GetComponent<Hit>(entityId);
                var attribute = _entityManager.GetComponent<Attribute>(entityId);

                hurt.value += attribute.attack;
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}