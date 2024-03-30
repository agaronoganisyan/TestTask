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
        private ICurrencyHandler _currencyHandler;

        private CompositeDisposable _disposable;
        
        [FormerlySerializedAs("_value")] [SerializeField] private TextMeshProUGUI _valueText;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _currencyHandler = container.Resolve<ICurrencyHandler>();

            _disposable = new CompositeDisposable();
        }

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _currencyHandler.Amount.Subscribe((value) => SetValue(value)).AddTo(_disposable);

            SetValue(_currencyHandler.Amount.Value);
        }

        private void SetValue(int value)
        {
            _valueText.text = value.ToString();
        }
    }
}