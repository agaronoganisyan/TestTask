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
        public int Index { get; private set; }
        
        private OfferHandler _offerHandler;

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

        public void SetParentAndPosition(Transform parent, int index, Vector2 position)
        {
            _rectTransform.SetParent(parent);
            _rectTransform.localScale = Vector3.one;
            
            SetPosition(index,position);
        }

        public void SetPosition(int index, Vector2 position)
        {
            Index = index;
            
            _indexText.text = index.ToString();
            _background.color = index % 2 == 0 ? _evenOfferColor : _oddOfferColor;
            _rectTransform.anchoredPosition = position;
        }

        public virtual void Setup(OfferHandler offerHandler)
        {
            _offerHandler = offerHandler;
            
            _purchaseButton.Setup(_offerHandler.Data.GetPrice());
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

        private void Purchase()
        {
            _offerHandler.Purchase();
        }
    }
}
