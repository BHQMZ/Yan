using System.Collections.Generic;

namespace Battle
{
    public class Visual
    {
        private readonly List<VisualSystem> _systems = new();

        public void Open(EntityManager entityManager)
        {
            _systems.Add(new LoadAssetSystem());
            _systems.Add(new CharacterSystem());

            _systems.ForEach(system =>
            {
                system.Init(entityManager);
            });
        }

        public void Update(int step, float deltaTime)
        {
            _systems.ForEach(system =>
            {
                system.Update(step, deltaTime);
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