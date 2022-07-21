using Assets.Level1.Scripts;

public class Game
{
    public GameStateMachine StateMachine;
    public Game(ICoroutineRunner coroutineRunner, DoubleJumpTrigger upgradeObject)
    {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
    }
}