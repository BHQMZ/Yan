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
                All = new []{typeof(Hit), typeof(Attribute)}
            });
        }

        public override void Update()
        {
            _entityQuery.GetEntityIdList().ForEach(entityId =>
            {
                var hit = _entityManager.GetComponent<Hit>(entityId);
                if (!hit.isActivate || hit.targetId == 0)
                {
                    hit.isActivate = false;
                    hit.curFrame = 0;
                    return;
                }

                var hurt = _entityManager.GetComponent<Hurt>(hit.targetId);
                if (hurt == null)
                {
                    hit.isActivate = false;
                    hit.curFrame = 0;
                    return;
                }

                hit.curFrame++;

                if (hit.curFrame == hit.hitFrame)
                {
                    var attribute = _entityManager.GetComponent<Attribute>(entityId);

                    hurt.value += attribute.attack;

                    Debug.Log("击中");
                }

                if (hit.curFrame < hit.actionFrame)
                {
                    return;
                }

                hit.isActivate = false;
                hit.curFrame = 0;
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }
    }
}