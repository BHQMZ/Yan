using System.Collections.Generic;

namespace Battle
{
    public class Control
    {
        private readonly List<System> _systems = new();

        public void Open(EntityManager entityManager)
        {
            _systems.Add(new PlayerControlSystem());
            _systems.Add(new CameraSystem());

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