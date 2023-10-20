using System;
using Cinemachine;
using Manager;
using UnityEngine;

namespace Battle
{
    public class LoadAssetSystem : VisualSystem
    {
        private EntityManager _entityManager;
        private EntityQuery _characterQuery;
        private EntityQuery _cameraQuery;
        private EntityQuery _bulletQuery;
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;

            _characterQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Asset), typeof(Character), typeof(Hero)}
            });
            _cameraQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Asset), typeof(CameraControl)}
            });
            _bulletQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Asset), typeof(Character), typeof(Bullet)}
            });

            _entityManager.AddRemoveComponentEvent<Asset>(DestroyAsset);
        }

        public override void Update(int step, float deltaTime)
        {
            _characterQuery.GetEntityIdList().ForEach(entityId =>
            {
                var character = _entityManager.GetComponent<Character>(entityId);
                if (character.Transform)
                {
                    return;
                }

                LoadAsset(entityId, AssetManager.CHARACTER_ASSETS, go =>
                {
                    character.Transform = go.transform;
                    character.Point = go.transform.Find("CharacterPoint");
                    character.Animator = go.GetComponentInChildren<Animator>();
                });
            });
            
            _cameraQuery.GetEntityIdList().ForEach(entityId =>
            {
                var cameraControl = _entityManager.GetComponent<CameraControl>(entityId);
                if (cameraControl.camera)
                {
                    return;
                }

                LoadAsset(entityId, AssetManager.CINEMACHINE_ASSETS, go =>
                {
                    cameraControl.camera = go;
                    cameraControl.cameraState = go.GetComponentInChildren<CinemachineStateDrivenCamera>();
                });
            });
            
            _bulletQuery.GetEntityIdList().ForEach(entityId =>
            {
                var bulletCharacter = _entityManager.GetComponent<Character>(entityId);
                if (bulletCharacter.Transform)
                {
                    return;
                }

                LoadAsset(entityId, AssetManager.BULLET_ASSETS, go =>
                {
                    bulletCharacter.Transform = go.transform;
                });
            });
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_characterQuery.desc);
            _entityManager.RemoveWithComponent(_cameraQuery.desc);
            _entityManager.RemoveWithComponent(_bulletQuery.desc);
        }

        private void LoadAsset(int entityId, string assetPath, Action<GameObject> callback)
        {
            var asset = _entityManager.GetComponent<Asset>(entityId);

            if (asset.GO == null && !asset.IsLoading && !string.IsNullOrEmpty(asset.AssetName))
            {
                asset.IsLoading = true;
                AssetManager.LoadAssetAsync<GameObject>(assetPath + asset.AssetName, go =>
                {
                    asset.IsLoading = false;
                    asset.GO = GameObject.Instantiate(go);
                    
                    callback.Invoke(asset.GO);
                });
            }
        }

        private void DestroyAsset(Component component)
        {
            if (component is not Asset asset || asset.GO == null)
            {
                return;
            }
                
            GameObject.Destroy(asset.GO);
            asset.GO = null;
        }
    }
}