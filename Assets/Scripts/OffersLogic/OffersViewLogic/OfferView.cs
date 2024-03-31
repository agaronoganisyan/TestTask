using System;
using CurrencyLogic;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic.PurchaseButtonLogic;
using PurchaseLogic.PurchaseSystemLogic;
using UniRx;
using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.UI;

namespace OffersLogic.OffersViewLogic
{
    public abstract class OfferView : MonoBehaviour, IDisposable
    {
        private OfferViewModel _offerViewModel;

        private PurchaseButton _purchaseButton;

        private CompositeDisposable _disposable;

        private RectTransform _rectTransform;

        [SerializeField] private Image _background;
        
        [SerializeField] private TextMeshProUGUI _indexText;

        [SerializeField] private Color _evenOfferColor;
        [SerializeField] private Color _oddOfferColor;

        [Inject]
        private void Construct()
        {
            _rectTransform = GetComponent<RectTransform>();
            _purchaseButton = GetComponentInChildren<PurchaseButton>();
            
            _disposable = new CompositeDisposable();
        }

        public virtual void Setup(OfferViewModel offerViewModel)
        {
            _offerViewModel = offerViewModel;

            _offerViewModel.Index.Subscribe((value) => SetIndex(value)).AddTo(_disposable);
            _offerViewModel.ParentTransform.Subscribe((value) => SetParent(value)).AddTo(_disposable);
            _offerViewModel.Position.Subscribe((value) => SetPosition(value)).AddTo(_disposable);       
            _offerViewModel.ReturnToPoolCommand.Subscribe((value) => ReturnToPool()).AddTo(_disposable);       

            
            _purchaseButton.Setup(_offerViewModel.Model.GetPrice());
            _purchaseButton.OnCLick.Subscribe((value) => Purchase()).AddTo(_disposable);
            gameObject.SetActive(true);
        }

        public virtual void ReturnToPool()
        {
            
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void SetParent(Transform parent)
        {
            _rectTransform.SetParent(parent);
            _rectTransform.localScale = Vector3.one;
        } 
        private void SetPosition(Vector2 position) => _rectTransform.anchoredPosition = position;

        private void SetIndex(int index)
        {
            _indexText.text = index.ToString();
            _background.color = index % 2 == 0 ? _evenOfferColor : _oddOfferColor;
        }
        
        private void Purchase()
        {
            _offerViewModel.Purchase();
        }
    }
}
