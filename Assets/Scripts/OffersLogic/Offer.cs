using System;
using OffersLogic.PurchaseButtonLogic;
using PurchaseLogic.PurchaseHandlerLogic;
using PurchaseLogic.PurchaseSystemLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic
{
    public abstract class Offer : MonoBehaviour, IDisposable
    {
        private IPurchaseSystem _purchaseSystem;
        private PurchaseButton _purchaseButton;

        private CompositeDisposable _disposable;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _purchaseSystem = container.Resolve<IPurchaseSystem>();
            
            _purchaseButton = GetComponentInChildren<PurchaseButton>();
        }

        public void Setup(int price)
        {
            _purchaseButton.Setup(price);

            _purchaseButton.OnCLick.Subscribe().AddTo(_disposable);
        }

        public void Dispose()
        {
            _purchaseButton?.Dispose();
            _disposable?.Dispose();
        }

        private void SuccessfulPurchase()
        {
            Execute();
        }

        protected abstract void Execute();
    }
}
