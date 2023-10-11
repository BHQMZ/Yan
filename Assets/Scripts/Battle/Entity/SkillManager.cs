namespace Battle
{
    public class SkillManager
    {
        public int CreateSkill(EntityManager entityManager)
        {
            var entityId = entityManager.CreateEntity();
            
            entityManager.AddComponent(entityId, new SkillBase());
            entityManager.AddComponent(entityId, new Hit());

            return entityId;
        }
    }
}