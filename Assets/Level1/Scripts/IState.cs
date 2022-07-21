public interface IState : IExitableState
{
    void Enter();
}
public interface IExitableState
{
    void Exit();
}

public interface IPayLoadState<Tpayload> : IExitableState
{
    void Enter(Tpayload payload);
}