namespace Battle
{
    public class CameraSystem : VisualSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _cameraQuery;
        private EntityQuery _playerQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _cameraQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(CameraControl)}
            });
            
            _playerQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Character), typeof(PlayerControl)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            var cameraList = _cameraQuery.GetEntityIdList();
            if (cameraList.Count <= 0)
            {
                return;
            }
            
            var playerList = _playerQuery.GetEntityIdList();
            if (playerList.Count <= 0)
            {
                return;
            }

            var camera = cameraList[0];

            var cameraControl = _entityManager.GetComponent<CameraControl>(camera);
            if (cameraControl.camera == null)
            {
                return;
            }
            
            var player = playerList[0];
            var character = _entityManager.GetComponent<Character>(player);
            if (character.Transform == null)
            {
                return;
            }

            cameraControl.cameraState.Follow = character.Transform;
            cameraControl.cameraState.LookAt = character.Transform;
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_cameraQuery.desc);
            _entityManager.RemoveWithComponent(_playerQuery.desc);
        }
    }
}