using System;
using InfrastructureLogic.StateMachineLogic.Simple;
using UniRx;

namespace PurchaseLogic.PurchaseProcessLogic
{
    public abstract class PurchaseProcessState<State> : ISimpleState<State> where State : Enum
    {
        public State StateKey { get; }

        public ReactiveCommand OnEntered;
        public ReactiveCommand OnExit;

        public PurchaseProcessState()
        {
            OnEntered = new ReactiveCommand();
            OnExit = new ReactiveCommand();
        }

        public void Update()
        {
        }

        public void Enter()
        {
            OnEntered?.Execute();
        }

        public void Exit()
        {
            OnExit?.Execute();
        }
    }
}