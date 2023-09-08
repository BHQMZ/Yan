using System;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class AssetManager
    {
        public const string CHARACTER_ASSETS = "Assets/Lib/Character/";
        public const string CINEMACHINE_ASSETS = "Assets/Lib/Cinemachine/";
        
        public static void LoadAssetAsync<T>(string assetPath, Action<T> callback)
        {
            Addressables.LoadAssetAsync<T>($"{assetPath}.prefab").Completed += handle =>
            {
                callback.Invoke(handle.Result);
            };
        }
        
        public static void LoadSceneAsync(string sceneName, Action callback)
        {
            SceneManager.LoadSceneAsync(sceneName).completed += handle =>
            {
                callback.Invoke();
            };
        }
    }
}