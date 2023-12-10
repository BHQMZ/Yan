using System.Linq;
using Google.Protobuf;
using UnityEngine;

namespace Battle
{
    public class PlayerNetworkSystem : NetworkSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _playerQuery;
        private EntityQuery _otherQuery;

        private int _curStep;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;
            _playerQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(MainPlayer), typeof(PlayerNetwork), typeof(PlayerControl)}
            });
            
            _otherQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(PlayerNetwork), typeof(PlayerControl)},
                None = new []{typeof(MainPlayer)}
            });
            
            App.Instance.OnVelocityAndPosition += OnVelocityAndPosition;
            App.Instance.OnReleaseSkill += OnReleaseSkill;
        }

        public override void Update(int step, float deltaTime)
        {
            if (_curStep == step)
            {
                return;
            }

            _curStep = step;
            _playerQuery.GetEntityIdList().ForEach(entityId =>
            {
                var playerControl = _entityManager.GetComponent<PlayerControl>(entityId);
                App.Instance.SendMatchState(
                    OpCodes.VelocityAndPosition,
                    new ProtoPlayerMove
                    {
                        Velocity = new ProtoVector
                        {
                            X = playerControl.Velocity.x,
                            Y = playerControl.Velocity.y,
                            Z = playerControl.Velocity.z,
                        }
                    }.ToByteArray()
                );
                
                var releaseSkillControl = _entityManager.GetComponent<ReleaseSkillControl>(entityId);
                if (releaseSkillControl.TriggerSkillIndex > 0)
                {
                    App.Instance.SendMatchState(
                        OpCodes.Input,
                        new ProtoPlayerRelease
                        {
                            SkillId = releaseSkillControl.TriggerSkillIndex
                        }.ToByteArray()
                    );
                }
            });

            // _otherQuery.GetEntityIdList().ForEach(entityId =>
            // {
            //     var transform = _entityManager.GetComponent<Transform>(entityId);
            //     
            // });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_playerQuery.desc);
            _entityManager.RemoveWithComponent(_otherQuery.desc);
        }

        private void OnVelocityAndPosition(string userSessionId, ProtoPlayerMove data)
        {
            var entityIdList = _otherQuery.GetEntityIdList();
            foreach (var entityId in entityIdList)
            {
                var playerNetwork = _entityManager.GetComponent<PlayerNetwork>(entityId);
                if (playerNetwork.SessionId == userSessionId)
                {
                    var playerControl = _entityManager.GetComponent<PlayerControl>(entityId);
                    playerControl.Velocity = new Vector3(data.Velocity.X, data.Velocity.Y, data.Velocity.Z);
                    break;
                }
            }
            
        }
        
        private void OnReleaseSkill(string userSessionId, ProtoPlayerRelease data)
        {
            var entityIdList = _otherQuery.GetEntityIdList();
            foreach (var entityId in entityIdList)
            {
                var playerNetwork = _entityManager.GetComponent<PlayerNetwork>(entityId);
                if (playerNetwork.SessionId == userSessionId)
                {
                    var releaseSkillControl = _entityManager.GetComponent<ReleaseSkillControl>(entityId);
                    releaseSkillControl.TriggerSkillIndex = data.SkillId;
                    break;
                }
            }
            
        }
    }
}