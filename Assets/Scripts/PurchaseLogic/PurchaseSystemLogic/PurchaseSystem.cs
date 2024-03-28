using System;
using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;
using Zenject;

namespace PurchaseLogic.PurchaseSystemLogic
{
    public class PurchaseSystem : IPurchaseSystem, IDisposable
    {
        private IPurchaseHandler _purchaseHandler;
        
        private ReactiveCommand _onCompleteCallback;
        private ReactiveCommand _onCancelCallback;
        private ReactiveCommand _onFailureCallback;

        private CompositeDisposable _disposable;
        
        public PurchaseSystem(DiContainer container)
        {
            _purchaseHandler = container.Resolve<IPurchaseHandler>();
        }

        public void Setup()
        {
            _purchaseHandler.OnPurchaseFinished.Subscribe((result) => ResultProcessing(result)).AddTo(_disposable);
        }

        public IPurchaseSystem OnCompleteCallback(ReactiveCommand callback)
        {
            _onCompleteCallback = callback;
            return this;
        }

        public IPurchaseSystem OnCancelCallback(ReactiveCommand callback)
        {
            _onCancelCallback = callback;
            return this;
        }

        public IPurchaseSystem OnFailureCallback(ReactiveCommand callback)
        {
            _onFailureCallback = callback;
            return this;
        }

        public void Purchase(int price)
        {
            _purchaseHandler.Process(price);
        }

        private void ResultProcessing(PurchaseResult result)
        {
            switch (result)
            {
                case PurchaseResult.Complete:
                    _onCompleteCallback?.Execute();
                    break;
                case PurchaseResult.Cancel:
                    _onCancelCallback?.Execute();
                    break;
                case PurchaseResult.Failure:
                    _onFailureCallback?.Execute();
                    break;
            }

            ClearCallbacks();
        }
        
        private void ClearCallbacks()
        {
            _onCompleteCallback = null;
            _onCancelCallback = null;
            _onFailureCallback = null;
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}