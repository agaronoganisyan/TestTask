using System;
using InfrastructureLogic.StateMachineLogic;
using InfrastructureLogic.StateMachineLogic.Simple;
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

    public class PurchaseProcess : IPurchaseProcess, IDisposable
    {
        public ReactiveCommand<PurchaseProcessType> OnStarted { get; }
        public ReactiveCommand<PurchaseResultType> OnFinished { get; }

        private IStateMachine<PurchaseProcessType> _stateMachine;
        
        private PurchaseResultType _purchaseResultType;
        
        public PurchaseProcess(DiContainer container)
        {
            OnStarted = new ReactiveCommand<PurchaseProcessType>();
            OnFinished = new ReactiveCommand<PurchaseResultType>();
            
            _stateMachine = container.Resolve<SimpleStateMachine<PurchaseProcessType>>();
            _stateMachine.Add(PurchaseProcessType.Confirm, container.Resolve<PurchaseConfirmState>());
            _stateMachine.Add(PurchaseProcessType.NotEnoughCurrency, container.Resolve<NotEnoughCurrencyState>());
        }

        public void Setup()
        {
        }

        public void Start(PurchaseProcessType purchaseProcessType)
        {
            _stateMachine.TransitToState(purchaseProcessType);
            OnStarted?.Execute(purchaseProcessType);
        }

        public void SetResult(PurchaseResultType purchaseResultType) => _purchaseResultType = purchaseResultType;
        
        public void Finish()
        {
            OnFinished?.Execute(_purchaseResultType);
        }

        public void Dispose()
        {
            OnStarted?.Dispose();
            OnFinished?.Dispose();
        }
    }
}