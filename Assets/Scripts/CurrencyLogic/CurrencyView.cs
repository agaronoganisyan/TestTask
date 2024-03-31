using System;
using OffersLogic.OffersViewLogic.PurchaseButtonLogic;
using PurchaseLogic.PurchaseSystemLogic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CurrencyLogic
{
    public class CurrencyView : MonoBehaviour
    {
        private ICurrencyViewModel _currencyViewModel;

        private CompositeDisposable _disposable;
        
        [SerializeField] private TextMeshProUGUI _valueText;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _currencyViewModel = container.Resolve<ICurrencyViewModel>();

            _disposable = new CompositeDisposable();
        }

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _currencyViewModel.Amount.Subscribe((value) => SetValue(value)).AddTo(_disposable);

            SetValue(_currencyViewModel.Amount.Value);
        }

        private void SetValue(int value)
        {
            _valueText.text = value.ToString();
        }
    }
}