using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    private GameApp _gameApp;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        _gameApp = new GameApp();
        _gameApp.Open();
    }

    private void Update()
    {
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
