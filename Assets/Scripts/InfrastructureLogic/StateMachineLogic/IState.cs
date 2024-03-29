using System;

namespace InfrastructureLogic.StateMachineLogic
{
    public interface IState<State> where State : Enum
    {
        State StateKey { get; }
        void Update();
    }
}