﻿using System;
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
        
        public override void Init(EntityManager entityManager)
        {
            _entityManager = entityManager;

            _characterQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Asset), typeof(Character)}
            });
            
            _cameraQuery = _entityManager.AddWithComponent(new EntityQueryDesc
            {
                All = new []{typeof(Asset), typeof(CameraControl)}
            });
        }

        public override void Update(int step, float deltaTime)
        {
            _characterQuery.GetEntityIdList().ForEach(entityId =>
            {
                var character = _entityManager.GetComponent<Character>(entityId);
                if (character.transform)
                {
                    return;
                }

                LoadAsset(entityId, AssetManager.CHARACTER_ASSETS, go =>
                {
                    character.transform = go.transform;
                    character.point = go.transform.Find("CharacterPoint");
                    character.animator = go.GetComponentInChildren<Animator>();
                    character.animator.speed = 0;
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
        }

        public override void Destroy()
        {
            _entityManager.RemoveWithComponent(_characterQuery.desc);
            _entityManager.RemoveWithComponent(_cameraQuery.desc);
        }

        private void LoadAsset(int entityId, string assetPath, Action<GameObject> callback)
        {
            var asset = _entityManager.GetComponent<Asset>(entityId);

            if (asset.go == null && !asset.isLoading && !string.IsNullOrEmpty(asset.assetName))
            {
                asset.isLoading = true;
                AssetManager.LoadAssetAsync<GameObject>(assetPath + asset.assetName, go =>
                {
                    asset.isLoading = false;
                    asset.go = GameObject.Instantiate(go);
                    
                    callback.Invoke(asset.go);
                });
            }
        }
    }
}