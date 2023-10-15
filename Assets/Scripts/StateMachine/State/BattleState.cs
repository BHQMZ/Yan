using System.Collections.Generic;
using Battle;
using Manager;

namespace StateMachine.State
{
    public class BattleState : StateBase
    {
        private int _step;
        private float _accumulatedTime;
        private const float _stepTime = 0.033f;
        
        private bool _isStart = false;

        private Logic _logic;
        private Visual _visual;

        public BattleState(StateMachineBase stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            AssetManager.LoadSceneAsync("Battle", () =>
            {
                var entityManager = new EntityManager();

                var player = entityManager.CreateEntity();
                entityManager.AddComponent(player, new Transform());
                entityManager.AddComponent(player, new Character());
                entityManager.AddComponent(player, new AnimatorControl());
                entityManager.AddComponent(player, new PlayerControl());
                entityManager.AddComponent(player, new Attribute
                {
                    hp = 100,
                    maxHp = 100,
                    attack = 10
                });
                entityManager.AddComponent(player, new Asset{
                    assetName = "Hero"
                });

                var heroAction = new Action();
                heroAction.ActionDataList.Add(new AttackActionData
                {
                    Attack = AttackActionEnum.Attack,
                    Frame = 60
                });
                entityManager.AddComponent(player, heroAction);

                var monster = entityManager.CreateEntity();
                entityManager.AddComponent(monster, new Transform());
                entityManager.AddComponent(monster, new Character());
                entityManager.AddComponent(monster, new AnimatorControl());
                entityManager.AddComponent(monster, new MonsterControl());
                entityManager.AddComponent(monster, new Attribute
                {
                    hp = 100,
                    maxHp = 100,
                    attack = 10
                });
                entityManager.AddComponent(monster, new Asset{
                    assetName = "Monster"
                });
                var monsterAction = new Action();
                monsterAction.ActionDataList.Add(new AttackActionData
                {
                    Attack = AttackActionEnum.Attack,
                    Frame = 60
                });
                entityManager.AddComponent(monster, monsterAction);


                var camera = entityManager.CreateEntity();
                entityManager.AddComponent(camera, new CameraControl());
                entityManager.AddComponent(camera, new Asset{
                    assetName = "Battle/Battle"
                });

                _logic = new Logic();
                _logic.Open(entityManager);
                _visual = new Visual();
                _visual.Open(entityManager);

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
        }

        public override void Exit()
        {
            _logic.Destroy();
            _visual.Destroy();
        }
    }
}