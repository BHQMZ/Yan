using System.Collections.Generic;

namespace Battle
{
    public class Logic
    {
        private readonly List<System> _systems = new();
        private EntityManager _entityManager;

        public void Open(EntityManager entityManager)
        {
            _entityManager = entityManager;
            
            _systems.Add(new BoundsSystem());
            _systems.Add(new MoveControlSystem());
            _systems.Add(new MonsterControlSystem());
            _systems.Add(new ReleaseSkillControlSystem());
            _systems.Add(new SkillBaseSystem());
            _systems.Add(new SkillConditionSystem());
            _systems.Add(new SkillTriggerSystem());
            _systems.Add(new SkillEffectSystem());
            _systems.Add(new ActionSystem());
            _systems.Add(new MoveSystem());
            _systems.Add(new HurtSystem());

            _systems.ForEach(system =>
            {
                system.Init(entityManager);
            });
        }

        public void Update(int step)
        {
            _systems.ForEach(system =>
            {
                system.Update(step);
            });
            _entityManager.UpdateWithComponent();
        }

        public void Destroy()
        {
            _systems.ForEach(system =>
            {
                system.Destroy();
            });
            _systems.Clear();
        }
    }
}