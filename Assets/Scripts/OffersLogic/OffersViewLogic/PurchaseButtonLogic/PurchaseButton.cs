using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace OffersLogic.OffersViewLogic.PurchaseButtonLogic
{
    public class PurchaseButton : MonoBehaviour, IDisposable
    {
        public ReactiveCommand OnCLick { get; private set; }
        private CompositeDisposable _disposable;
        
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _price;
        
        public void Setup(int price)
        {
            _disposable = new CompositeDisposable();
            OnCLick = new ReactiveCommand();
            
            _price.text = price > 0 ? $"{price}$" : "FREE";
            _button.OnClickAsObservable().Subscribe((value) => OnCLick.Execute()).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
            OnCLick?.Dispose();
        }
    }
}