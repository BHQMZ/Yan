namespace Battle
{
    public abstract class NetworkSystem
    {
        public abstract void Init(EntityManager entityManager);

        public abstract void Update(int step, float deltaTime);

        public abstract void Destroy();
    }
}