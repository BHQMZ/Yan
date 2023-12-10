using System.Linq;
using Nakama;

namespace Battle
{
    public class SpawnNetworkSystem : NetworkSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _entityQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _entityQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerNetwork)}
            });

            App.Instance.OnSpawnPlayer += OnSpawnPlayer;
        }

        public override void Update(int step, float deltaTime)
        {
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_entityQuery.desc);
        }

        private void OnSpawnPlayer(string matchId, IUserPresence user)
        {
            var entityIdList = _entityQuery.GetEntityIdList();
            if (entityIdList.Select(entityId => _entityManager.GetComponent<PlayerNetwork>(entityId)).Any(playerNetwork => playerNetwork.SessionId == user.SessionId))
            {
                return;
            }

            var player = CharacterManager.CreateHero(_entityManager);
            _entityManager.AddComponent(player, new PlayerNetwork
            {
                SessionId = user.SessionId
            });
            if (App.Instance.LocalUser.SessionId == user.SessionId)
            {
                _entityManager.AddComponent(player, new MainPlayer());
            }
        }
    }
}