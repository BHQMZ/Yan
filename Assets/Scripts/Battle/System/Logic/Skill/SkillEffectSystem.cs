using Battle.Effect;
using UnityEngine;

namespace Battle
{
    public class SkillEffectSystem : System
    {
        private EntityManager _entityManager;
        private EntityQuery _hitQuery;
        private EntityQuery _rangeHitQuery;
        private EntityQuery _bulletQuery;

        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _hitQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(Hit)}
            });
            _rangeHitQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(RangeHit)}
            });
            _bulletQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(SkillBase), typeof(CreateBullet)}
            });
        }

        public override void Update(int step)
        {
            _hitQuery.GetEntityIdList().ForEach(TaskEffectHit);
            _rangeHitQuery.GetEntityIdList().ForEach(TaskEffectRangeHit);
            _bulletQuery.GetEntityIdList().ForEach(TaskEffectBullet);
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_hitQuery.desc);
            _entityManager.RemoveWithComponent(_rangeHitQuery.desc);
            _entityManager.RemoveWithComponent(_bulletQuery.desc);
        }

        private void TaskEffectHit(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (!skillBase.IsActivate)
            {
                // 技能未激活
                return;
            }

            if (skillBase.IsTakeOver)
            {
                // 技能生效结束
                return;
            }

            if (!skillBase.IsTakeEffect)
            {
                // 技能未生效不做处理
                return;
            }

            var moveControl = _entityManager.GetComponent<MoveControl>(entityId);
            var hit = _entityManager.GetComponent<Hit>(entityId);
            var releaseAttr = _entityManager.GetComponent<Attribute>(skillBase.Release);
            var value = (int) (hit.AddValue * releaseAttr.attack);

            skillBase.TargetList.ForEach(target =>
            {
                var hurt = _entityManager.CreateEntity();
                _entityManager.AddComponent(hurt, new Hurt
                {
                    Release = skillBase.Release,
                    Target = target,
                    Value = value
                });
                // 临时加个击退
                var back = _entityManager.CreateEntity();
                _entityManager.AddComponent(back, new MoveControl
                {
                    Target = target,
                    Direction = moveControl.Direction,
                    Time = 10,
                    Speed = 2
                });
            });

            skillBase.IsTakeOver = true;
        }

        private void TaskEffectRangeHit(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (!skillBase.IsActivate)
            {
                // 技能未激活
                return;
            }

            if (skillBase.IsTakeOver)
            {
                // 技能生效结束
                return;
            }

            if (!skillBase.IsTakeEffect)
            {
                // 技能未生效不做处理
                return;
            }

            var rangeSkillEntityId = SkillManager.CreateRangeSkill(_entityManager);
            var rangeSkillBase = _entityManager.GetComponent<SkillBase>(rangeSkillEntityId);
            rangeSkillBase.Release = skillBase.Release;

            var releaseTransform = _entityManager.GetComponent<Transform>(skillBase.Release);
            var rangeSkillTransform = _entityManager.GetComponent<Transform>(rangeSkillEntityId);
            rangeSkillTransform.Position = releaseTransform.Position + (releaseTransform.IsRight ? Vector3.right : Vector3.left) * 5;

            skillBase.IsTakeOver = true;
        }
        
        private void TaskEffectBullet(int entityId)
        {
            var skillBase = _entityManager.GetComponent<SkillBase>(entityId);
            if (!skillBase.IsActivate)
            {
                // 技能未激活
                return;
            }

            if (skillBase.IsTakeOver)
            {
                // 技能生效结束
                return;
            }

            if (!skillBase.IsTakeEffect)
            {
                // 技能未生效不做处理
                return;
            }

            var bulletEntityId = SkillManager.CreateBulletSkill(_entityManager);
            var rangeSkillBase = _entityManager.GetComponent<SkillBase>(bulletEntityId);
            rangeSkillBase.Release = skillBase.Release;

            var releaseTransform = _entityManager.GetComponent<Transform>(skillBase.Release);
            var rangeSkillTransform = _entityManager.GetComponent<Transform>(bulletEntityId);
            rangeSkillTransform.Position = releaseTransform.Position + (releaseTransform.IsRight ? Vector3.right : Vector3.left) * 5 + Vector3.up * 5;

            var createBullet = _entityManager.GetComponent<CreateBullet>(entityId);
            var moveControl = _entityManager.GetComponent<MoveControl>(bulletEntityId);
            moveControl.Direction = releaseTransform.IsRight ? Vector3.right : Vector3.left;
            moveControl.Speed = createBullet.Speed;
            moveControl.Time = createBullet.Time;

            skillBase.IsTakeOver = true;
        }
    }
}