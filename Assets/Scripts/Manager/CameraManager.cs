using Cinemachine;
using UnityEngine;

namespace Manager
{
    public class CameraManager
    {
        private static string _currentCameraName;
        private static CinemachineStateDrivenCamera _cameraState;
        private static Transform _followTarget;
        private static Transform _lookAtTarget;
        
        public static void ChangeCamera(string cameraName)
        {
            _currentCameraName = cameraName;
            AssetManager.LoadAssetAsync<GameObject>($"{AssetManager.CINEMACHINE_ASSETS}{cameraName}/{cameraName}", go =>
            {
                if (_currentCameraName != cameraName)
                {
                    return;
                }

                var camera = GameObject.Instantiate(go);
                _cameraState = camera.GetComponentInChildren<CinemachineStateDrivenCamera>();
                if (_followTarget != null)
                {
                    _cameraState.Follow = _followTarget;
                }
                if (_lookAtTarget != null)
                {
                    _cameraState.LookAt = _lookAtTarget;
                }
            });
        }
        
        public static void SetFollowTarget(Transform target)
        {
            _followTarget = target;
            if (_cameraState == null)
            {
                return;
            }
            _cameraState.Follow = target;
        }
        
        public static void SetLookAtTarget(Transform target)
        {
            _lookAtTarget = target;
            if (_cameraState == null)
            {
                return;
            }
            _cameraState.LookAt = target;
        }
    }
}