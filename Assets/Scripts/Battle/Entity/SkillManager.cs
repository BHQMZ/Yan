using Battle.Condition;
using Battle.Effect;
using Battle.Trigger;

namespace Battle
{
    public class SkillManager
    {
        public static int CreateSkill(EntityManager entityManager)
        {
            var entityId = entityManager.CreateEntity();
            
            entityManager.AddComponent(entityId, new SkillBase());
            entityManager.AddComponent(entityId, new Release());
            entityManager.AddComponent(entityId, new TriggerAction
            {
                AttackAction = AttackActionEnum.Attack
            });
            entityManager.AddComponent(entityId, new RangeHit());

            return entityId;
        }
        
        public static int CreateRangeSkill(EntityManager entityManager)
        {
            var entityId = entityManager.CreateEntity();

            entityManager.AddComponent(entityId, new SkillBase());
            entityManager.AddComponent(entityId, new Duration
            {
                Time = 1
            });
            entityManager.AddComponent(entityId, new TriggerBounds
            {
                TargetCount = 1
            });
            entityManager.AddComponent(entityId, new Hit
            {
                AddValue = 1f
            });

            entityManager.AddComponent(entityId, new Transform());
            entityManager.AddComponent(entityId, new Bounds
            {
                Query = entityManager.AddWithComponent(new EntityQueryDesc
                {
                    All = new[] { typeof(PlayerControl) }
                })
            });
            entityManager.AddComponent(entityId, new Ball
            {
                Radius = 10
            });

            return entityId;
        }
        
        public static int CreateShootSkill(EntityManager entityManager)
        {
            var entityId = entityManager.CreateEntity();
            
            entityManager.AddComponent(entityId, new SkillBase());
            entityManager.AddComponent(entityId, new Release());
            entityManager.AddComponent(entityId, new TriggerAction
            {
                AttackAction = AttackActionEnum.Attack
            });
            entityManager.AddComponent(entityId, new CreateBullet
            {
                Speed = 2,
                Time = 100,
            });

            return entityId;
        }
        
        public static int CreateBulletSkill(EntityManager entityManager)
        {
            var entityId = entityManager.CreateEntity();

            entityManager.AddComponent(entityId, new SkillBase());
            entityManager.AddComponent(entityId, new Count()
            {
                ActivateCount = 1
            });
            entityManager.AddComponent(entityId, new TriggerBounds
            {
                TargetCount = 1,
                IsHaveTargetTrigger = true
            });
            entityManager.AddComponent(entityId, new Hit
            {
                AddValue = 1f
            });

            entityManager.AddComponent(entityId, new Transform());
            entityManager.AddComponent(entityId, new Bounds
            {
                Query = entityManager.AddWithComponent(new EntityQueryDesc
                {
                    All = new[] { typeof(MonsterControl) }
                })
            });
            entityManager.AddComponent(entityId, new Ball
            {
                Radius = 1
            });
            entityManager.AddComponent(entityId, new MoveControl
            {
                // 子弹的移动控制直接选自身就好
                Target = entityId
            });
            entityManager.AddComponent(entityId, new Asset
            {
                AssetName = "Bullet"
            });
            entityManager.AddComponent(entityId, new Bullet());
            entityManager.AddComponent(entityId, new Character());

            return entityId;
        }
    }
}