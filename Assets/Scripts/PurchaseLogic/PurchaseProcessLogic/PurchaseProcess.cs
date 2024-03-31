using System;
using InfrastructureLogic.StateMachineLogic;
using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;
using Zenject;

namespace PurchaseLogic.PurchaseProcessLogic
{
    public enum PurchaseProcessType
    {
        None,
        Confirm,
        NotEnoughCurrency
    }

    public class PurchaseProcess : IPurchaseProcess
    {
        public ReactiveCommand<PurchaseProcessType> OnStarted { get; }
        public ReactiveCommand OnResultReceived { get; }
        public ReactiveCommand<PurchaseResultType> OnFinished { get; }

        private IStateMachine<PurchaseProcessType> _stateMachine;
        
        private PurchaseResultType _purchaseResultType;
        
        public PurchaseProcess(DiContainer container)
        {
            OnStarted = new ReactiveCommand<PurchaseProcessType>();
            OnResultReceived = new ReactiveCommand();
            OnFinished = new ReactiveCommand<PurchaseResultType>();
            
            _stateMachine = container.Resolve<IStateMachine<PurchaseProcessType>>();
            _stateMachine.Add(PurchaseProcessType.Confirm, container.Resolve<PurchaseConfirmState>());
            _stateMachine.Add(PurchaseProcessType.NotEnoughCurrency, container.Resolve<NotEnoughCurrencyState>());
        }
        
        public void Start(PurchaseProcessType purchaseProcessType)
        {
            _stateMachine.TransitToState(purchaseProcessType);
            OnStarted?.Execute(purchaseProcessType);
        }

        public void SetResult(PurchaseResultType purchaseResultType)
        {
            _purchaseResultType = purchaseResultType;

            OnResultReceived?.Execute();
        }
        
        public void Finish()
        {
            OnFinished?.Execute(_purchaseResultType);
        }
    }
}