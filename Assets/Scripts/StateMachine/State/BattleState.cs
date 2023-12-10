using Battle;
using Manager;

namespace StateMachine.State
{
    public class BattleState : StateBase
    {
        private int _step;
        private float _accumulatedTime;
        private const float _stepTime = 0.033f;
        
        private bool _isStart;

        private Logic _logic;
        private Visual _visual;
        private Network _network;
        
        private float _syncFrequency = 0.033f;
        private float _syncTimer;

        private EntityManager _entityManager;

        public BattleState(StateMachineBase stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            AssetManager.LoadSceneAsync("Battle", () =>
            {
                var entityManager = new EntityManager();
                _entityManager = entityManager;

                // CharacterManager.CreateHero(entityManager);

                CharacterManager.CreateMonster(entityManager);

                var camera = entityManager.CreateEntity();
                entityManager.AddComponent(camera, new CameraControl());
                entityManager.AddComponent(camera, new Asset{
                    AssetName = "Battle/Battle"
                });

                _logic = new Logic();
                _logic.Open(entityManager);
                _visual = new Visual();
                _visual.Open(entityManager);
                _network = new Network();
                _network.Open(entityManager);

                _isStart = true;
            });
        }

        public override void Update(float deltaTime, float frameCount)
        {
            if (!_isStart)
            {
                return;
            }
            _accumulatedTime += deltaTime;
            while (_accumulatedTime >= _stepTime)
            {
                _accumulatedTime -= _stepTime;
                _step++;
                _logic.Update(_step);
            }
        }

        public override void LateUpdate(float deltaTime, float frameCount)
        {
            if (!_isStart)
            {
                return;
            }
            _visual.Update(_step, deltaTime);

            _syncTimer += deltaTime;
            if (_syncTimer >= _syncFrequency)
            {
                _syncTimer = 0;
                _network.Update(_step, deltaTime);
            }
        }

        public override void Exit()
        {
            _logic.Destroy();
            _visual.Destroy();
            _network.Destroy();
        }
    }
}