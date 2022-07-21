using System;
using System.Collections.Generic;

public class GameStateMachine
{
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(SceneLoader sceneLoader)
    {
        _states = new Dictionary<Type, IExitableState>
        {
            [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader),
            [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader)
        };
    }
    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();
        TState state = GetState<TState>();
        _activeState = state;
        return state;
    }
    private TState GetState<TState>() where TState : class, IExitableState =>
        _states[typeof(TState)] as TState;
    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, Tpayload>(Tpayload payload) where TState : class, IPayLoadState<Tpayload>
    {
        TState state = ChangeState<TState>();
        state.Enter(payload);
    }
}