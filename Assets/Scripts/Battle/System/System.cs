using System.Collections.Generic;

namespace Battle
{
    public abstract class System
    {
        public abstract void Init(EntityManager entityManager);

        public abstract void Update();

        public abstract void Destroy();
    }
}