using StateMachine;

public class GameApp
{
    private MainStateMachine _main;
    
    public void Open()
    {
        _main = new MainStateMachine();
    }
    
    public void Update(float deltaTime, float frameCount)
    {
        _main?.Update(deltaTime, frameCount);
    }

    public void LateUpdate(float deltaTime, float frameCount)
    {
        _main?.LateUpdate(deltaTime, frameCount);
    }

    public void Destroy()
    {
    }
}
