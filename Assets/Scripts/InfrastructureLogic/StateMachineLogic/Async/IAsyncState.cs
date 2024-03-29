using System;
using Cysharp.Threading.Tasks;

namespace InfrastructureLogic.StateMachineLogic.Async
{
    public interface IAsyncState<State> : IState<State> where State : Enum
    {
        UniTask Enter();
        UniTask Exit();
    }
}