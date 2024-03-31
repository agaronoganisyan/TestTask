using CurrencyLogic;
using OffersLogic.OfferHandlerLogic.OffersListHandlerLogic;
using OffersLogic.OffersDataLogic;
using PurchaseLogic.PurchaseSystemLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.OfferHandlerLogic
{
    public abstract class OfferViewModel
    {
        public OfferModel Model { get; private set; }

        private IPurchaseSystem _purchaseSystem;
        private IOffersListViewModel _offersListViewModel;
        protected ICurrencyViewModel CurrencyViewModel;
        
        private ReactiveCommand _completeCallback;
        private ReactiveCommand _cancelCallback;
        private ReactiveCommand _failureCallback;
        
        private CompositeDisposable _disposable;
        
        public OfferViewModel(DiContainer container)
        {
            _purchaseSystem = container.Resolve<IPurchaseSystem>();
            _offersListViewModel = container.Resolve<IOffersListViewModel>();
            CurrencyViewModel = container.Resolve<ICurrencyViewModel>();
            
            _completeCallback = new ReactiveCommand();
            _cancelCallback = new ReactiveCommand();
            _failureCallback = new ReactiveCommand();
            
            _disposable = new CompositeDisposable();
        }

        public OfferViewModel Setup(OfferModel model)
        {
            Model = model;
            
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
                .Purchase(Model.GetPrice());
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
            CurrencyViewModel.Decrease(Model.GetPrice());
            _offersListViewModel.Remove(Model);
            
            Debug.Log("PURCHASE COMPLETE");
            
            Execute();
        }

        protected virtual void Execute()
        {
            
        }
    }
}