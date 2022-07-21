public class BootStrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private const string SceneName = "Menu";
    public BootStrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }

    public void EnterLoadLevel()
    {
        _gameStateMachine.Enter<LoadLevelState, string>(SceneName);
    }
    public void Exit()
    {

    }
    public void Enter()
    {
        _sceneLoader.LoadScene(SceneName, onLoad: EnterLoadLevel);
    }
}