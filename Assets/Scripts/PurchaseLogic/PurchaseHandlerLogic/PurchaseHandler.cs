using System;
using CurrencyLogic;
using InfoCanvasLogic.NotEnoughCurrencyLogic;
using InfoCanvasLogic.PurchaseConfirmLogic;
using UniRx;
using Zenject;

namespace PurchaseLogic.PurchaseHandlerLogic
{
    public enum PurchaseResult
    {
        None,
        Complete,
        Cancel,
        Failure
    }
    
    public class PurchaseHandler : IPurchaseHandler, IDisposable
    {
        public ReactiveCommand<PurchaseResult> OnPurchaseFinished { get; }

        private ICurrencyHandler _currencyHandler;
        private IPurchaseConfirmSystem _purchaseConfirmSystem;
        private INotEnoughCurrencySystem _notEnoughCurrencySystem;

        private CompositeDisposable _disposable;
        
        public PurchaseHandler(DiContainer container)
        {
            _currencyHandler = container.Resolve<ICurrencyHandler>();
            _purchaseConfirmSystem = container.Resolve<IPurchaseConfirmSystem>();
            _notEnoughCurrencySystem = container.Resolve<INotEnoughCurrencySystem>();

            OnPurchaseFinished = new ReactiveCommand<PurchaseResult>();
        }

        public void Setup()
        {
            _purchaseConfirmSystem.OnFinished.Subscribe((result) => OnPurchaseFinished.Execute(result))
                .AddTo(_disposable);
            
            _notEnoughCurrencySystem.OnFinished.Subscribe((result) => OnPurchaseFinished.Execute(result))
                .AddTo(_disposable);
        }

        public void Process(int price)
        {
            if (_currencyHandler.Amount.Value >= price)
            {
                _purchaseConfirmSystem.Start();
            }
            else
            {
                _notEnoughCurrencySystem.Start();
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}