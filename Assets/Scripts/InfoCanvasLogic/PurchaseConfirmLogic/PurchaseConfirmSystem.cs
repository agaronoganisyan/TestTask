using System;
using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;

namespace InfoCanvasLogic.PurchaseConfirmLogic
{
    public class PurchaseConfirmSystem : IPurchaseConfirmSystem, IDisposable
    {
        public ReactiveCommand OnStarted { get; }
        public ReactiveCommand<PurchaseResult> OnFinished { get; }

        private PurchaseResult _purchaseResult;
        
        public PurchaseConfirmSystem()
        {
            OnStarted = new ReactiveCommand();
            OnFinished = new ReactiveCommand<PurchaseResult>();
        }

        public void Start()
        {
            OnStarted?.Execute();
        }

        public void SetResult(PurchaseResult purchaseResult) => _purchaseResult = purchaseResult;
        
        public void Finish()
        {
            OnFinished?.Execute(_purchaseResult);
        }

        public void Dispose()
        {
            OnStarted?.Dispose();
            OnFinished?.Dispose();
        }
    }
}