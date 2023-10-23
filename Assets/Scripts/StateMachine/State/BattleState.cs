using System.Collections.Generic;
using Battle;
using Manager;
using UnityEngine;
using Transform = Battle.Transform;

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

                var player = entityManager.CreateEntity();
                entityManager.AddComponent(player, new Transform());
                entityManager.AddComponent(player, new Ball
                {
                    Radius = 5,
                    Offset = new Vector3(0, 4.5f, 0)
                });
                entityManager.AddComponent(player, new Character());
                entityManager.AddComponent(player, new Hero());
                entityManager.AddComponent(player, new AnimatorControl());
                entityManager.AddComponent(player, new PlayerControl());
                entityManager.AddComponent(player, new Attribute
                {
                    hp = 100,
                    maxHp = 100,
                    attack = 5
                });
                entityManager.AddComponent(player, new Asset{
                    AssetName = "Hero"
                });
                var heroAction = new Action();
                heroAction.ActionDataList.Add(new AttackActionData
                {
                    Attack = AttackActionEnum.Attack,
                    Frame = 20,
                    EventFrame = 2
                });
                entityManager.AddComponent(player, heroAction);
                entityManager.AddComponent(player, new ReleaseSkillControl
                {
                    SkillList = new []
                    {
                        new ReleaseSkillData
                        {
                            Skill = SkillManager.CreateShootSkill(entityManager)
                        }
                    }
                });


                var monster = entityManager.CreateEntity();
                entityManager.AddComponent(monster, new Transform());
                entityManager.AddComponent(monster, new Ball
                {
                    Radius = 5,
                    Offset = new Vector3(0, 4.5f, 0)
                });
                entityManager.AddComponent(monster, new Character());
                entityManager.AddComponent(monster, new Hero());
                entityManager.AddComponent(monster, new AnimatorControl());
                entityManager.AddComponent(monster, new MonsterControl());
                entityManager.AddComponent(monster, new Attribute
                {
                    hp = 100,
                    maxHp = 100,
                    attack = 10
                });
                entityManager.AddComponent(monster, new Asset{
                    AssetName = "Monster"
                });
                var monsterAction = new Action();
                monsterAction.ActionDataList.Add(new AttackActionData
                {
                    Attack = AttackActionEnum.Attack,
                    Frame = 60,
                    EventFrame = 37
                });
                entityManager.AddComponent(monster, monsterAction);
                entityManager.AddComponent(monster, new ReleaseSkillControl
                {
                    SkillList = new []
                    {
                        new ReleaseSkillData
                        {
                            Skill = SkillManager.CreateSkill(entityManager)
                        }
                    }
                });


                var camera = entityManager.CreateEntity();
                entityManager.AddComponent(camera, new CameraControl());
                entityManager.AddComponent(camera, new Asset{
                    AssetName = "Battle/Battle"
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