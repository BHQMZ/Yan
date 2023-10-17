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
            entityManager.AddComponent(entityId, new Hit
            {
                AddValue = 1f
            });

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
            });
            entityManager.AddComponent(entityId, new Hit
            {
                AddValue = 1f
            });

            entityManager.AddComponent(entityId, new Transform());
            entityManager.AddComponent(entityId, new Bounds());

            return entityId;
        }
    }
}