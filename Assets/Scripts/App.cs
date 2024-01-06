using Manager;
using UnityEngine;

public class App : MonoBehaviour
{
    public static NetworkManager Network;
    public static AssetManager Asset;
    
    public NakamaConnection NakamaConnection;
    
    private GameApp _gameApp;

    public static App Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        Instance = this;

        // 网络管理器
        Network = new NetworkManager(this);

        // 资源管理器
        Asset = new AssetManager();
 
        // 玩法
        _gameApp = new GameApp();
        _gameApp.Open();
    }

    private void Update()
    {
        Network.Update();
        _gameApp?.Update(Time.deltaTime, Time.frameCount);
    }

    private void LateUpdate()
    {
        _gameApp?.LateUpdate(Time.deltaTime, Time.frameCount);
    }

    private void OnDestroy()
    {
        _gameApp?.Destroy();
    }
}
