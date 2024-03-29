using System;
using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;

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

        private PurchaseResultType _purchaseResultType;
        
        public PurchaseProcess()
        {
            OnStarted = new ReactiveCommand<PurchaseProcessType>();
            OnFinished = new ReactiveCommand<PurchaseResultType>();
        }

        public void Start(PurchaseProcessType purchaseProcessType)
        {
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