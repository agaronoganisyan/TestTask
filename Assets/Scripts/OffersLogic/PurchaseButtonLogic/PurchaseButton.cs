using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace OffersLogic.PurchaseButtonLogic
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
            
            _price.text = $"{price}$";
            _button.OnClickAsObservable().Subscribe((value) => OnCLick.Execute()).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
            OnCLick?.Dispose();
        }
    }
}