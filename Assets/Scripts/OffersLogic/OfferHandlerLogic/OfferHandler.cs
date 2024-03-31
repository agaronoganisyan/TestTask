using CurrencyLogic;
using OffersLogic.OfferHandlerLogic.OffersListHandlerLogic;
using OffersLogic.OffersDataLogic;
using PurchaseLogic.PurchaseSystemLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.OfferHandlerLogic
{
    public abstract class OfferHandler
    {
        public OfferData Data { get; private set; }

        private IPurchaseSystem _purchaseSystem;
        private IOffersListHandler _offersListHandler;
        protected ICurrencyHandler _currencyHandler;
        
        private ReactiveCommand _completeCallback;
        private ReactiveCommand _cancelCallback;
        private ReactiveCommand _failureCallback;
        
        private CompositeDisposable _disposable;
        
        public OfferHandler(DiContainer container)
        {
            _purchaseSystem = container.Resolve<IPurchaseSystem>();
            _offersListHandler = container.Resolve<IOffersListHandler>();
            _currencyHandler = container.Resolve<ICurrencyHandler>();
            
            _completeCallback = new ReactiveCommand();
            _cancelCallback = new ReactiveCommand();
            _failureCallback = new ReactiveCommand();
            
            _disposable = new CompositeDisposable();
        }

        public OfferHandler Setup(OfferData data)
        {
            Data = data;
            
            _completeCallback.Subscribe(_ => CompletedPurchase()).AddTo(_disposable);
            _cancelCallback.Subscribe(_ => CanceledPurchase()).AddTo(_disposable);
            _failureCallback.Subscribe(_ => FailedPurchase()).AddTo(_disposable);
            
            return this;
        }

        public void Purchase()
        {
            _purchaseSystem
                .OnCompleteCallback(_completeCallback)
                .OnCancelCallback(_cancelCallback)
                .OnFailureCallback(_failureCallback)
                .Purchase(Data.GetPrice());
        }
        
        private void FailedPurchase()
        {
            Debug.Log("PURCHASE FAILED");
        }
        
        private void CanceledPurchase()
        {
            Debug.Log("PURCHASE CANCELED");
        }
        
        private void CompletedPurchase()
        {
            _currencyHandler.Decrease(Data.GetPrice());
            _offersListHandler.Remove(this);
            
            Debug.Log("PURCHASE COMPLETE");
            
            Execute();
        }

        protected virtual void Execute()
        {
            
        }
    }
}