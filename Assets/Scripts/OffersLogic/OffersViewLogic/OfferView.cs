using System;
using CurrencyLogic;
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
        private OfferData _data;
        
        private IPurchaseSystem _purchaseSystem;
        private IOffersHandler _offersHandler;
        private ICurrencyHandler _currencyHandler;
        
        private PurchaseButton _purchaseButton;

        private ReactiveCommand _completeCallback;
        private ReactiveCommand _cancelCallback;
        private ReactiveCommand _failureCallback;
        
        private CompositeDisposable _disposable;

        private RectTransform _rectTransform;

        public int Index { get; private set; }

        [SerializeField] private Image _background;
        
        [SerializeField] private TextMeshProUGUI _indexText;

        [SerializeField] private Color _evenOfferColor;
        [SerializeField] private Color _oddOfferColor;

        [Inject]
        private void Construct(DiContainer container)
        {
            _purchaseSystem = container.Resolve<IPurchaseSystem>();
            _offersHandler = container.Resolve<IOffersHandler>();
            _currencyHandler = container.Resolve<ICurrencyHandler>();
            
            _rectTransform = GetComponent<RectTransform>();
            _purchaseButton = GetComponentInChildren<PurchaseButton>();
            
            _completeCallback = new ReactiveCommand();
            _cancelCallback = new ReactiveCommand();
            _failureCallback = new ReactiveCommand();
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

        public virtual void Setup(OfferData data)
        {
            _data = data;
            
            _completeCallback.Subscribe(_ => CompletedPurchase()).AddTo(_disposable);
            _cancelCallback.Subscribe(_ => CanceledPurchase()).AddTo(_disposable);
            _failureCallback.Subscribe(_ => FailedPurchase()).AddTo(_disposable);
            
            _purchaseButton.Setup(_data.GetPrice());
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
            _purchaseSystem
                .OnCompleteCallback(_completeCallback)
                .OnCancelCallback(_cancelCallback)
                .OnFailureCallback(_failureCallback)
                .Purchase(_data.GetPrice());
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
            _currencyHandler.Decrease(_data.GetPrice());
            _offersHandler.Remove(_data);
            
            Debug.Log("PURCHASE COMPLETE");
            
            Execute();
        }

        protected virtual void Execute()
        {
            
        }
    }
}
