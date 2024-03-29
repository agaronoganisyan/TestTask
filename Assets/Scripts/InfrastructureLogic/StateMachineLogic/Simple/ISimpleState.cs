using System;

namespace InfrastructureLogic.StateMachineLogic.Simple
{
    public interface ISimpleState<State> : IState<State> where State : Enum
    {
        void Enter();
        void Exit();
    }
}