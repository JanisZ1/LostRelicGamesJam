using Assets.Level1.Scripts;
using UnityEngine;

public class GameBootStrapper : MonoBehaviour, ICoroutineRunner
{
    private Game _game;
    [SerializeField] private DoubleJumpTrigger _doubleJumpTrigger;
    private void Awake()
    {
        _game = new Game(this, _doubleJumpTrigger);
        _game.StateMachine.Enter<BootStrapState>();

        DontDestroyOnLoad(this);
    }
}