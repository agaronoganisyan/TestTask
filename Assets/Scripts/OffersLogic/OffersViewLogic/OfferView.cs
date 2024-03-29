using System;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic.PurchaseButtonLogic;
using PurchaseLogic.PurchaseSystemLogic;
using UniRx;
using UnityEngine;
using Zenject;
using PoolLogic;
using TMPro;

namespace OffersLogic.OffersViewLogic
{
    public abstract class OfferView : MonoBehaviour, IDisposable
    {
        private IPurchaseSystem _purchaseSystem;
        private PurchaseButton _purchaseButton;
    
        private CompositeDisposable _disposable;

        private RectTransform _rectTransform;
        
        [SerializeField] private TextMeshProUGUI _id;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _purchaseSystem = container.Resolve<IPurchaseSystem>();

            _rectTransform = GetComponent<RectTransform>();
            _purchaseButton = GetComponentInChildren<PurchaseButton>();
        }

        public void SetParentAndPosition(Transform parent, Vector3 position)
        {
            _rectTransform.SetParent(parent);
            _rectTransform.anchoredPosition3D = position;
            _rectTransform.localScale = Vector3.one;
        }

        public virtual void Setup(OfferData data)
        {
            _purchaseButton.Setup(0);
    
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
