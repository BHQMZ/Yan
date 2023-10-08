using System.Collections.Generic;

namespace Battle
{
    public class Logic
    {
        private readonly List<System> _systems = new();

        public void Open(EntityManager entityManager)
        {
            _systems.Add(new MonsterControlSystem());
            _systems.Add(new SkillObjectSystem());
            _systems.Add(new SkillSystem());
            _systems.Add(new SkillEffectSystem());
            _systems.Add(new ActionSystem());
            _systems.Add(new BoundsSystem());
            _systems.Add(new MoveSystem());
            _systems.Add(new HurtSystem());

            _systems.ForEach(system =>
            {
                system.Init(entityManager);
            });
        }

        public void Update()
        {
            _systems.ForEach(system =>
            {
                system.Update();
            });
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