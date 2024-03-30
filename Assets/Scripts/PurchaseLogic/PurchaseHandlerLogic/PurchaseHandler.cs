using System;
using CurrencyLogic;
using InfoCanvasLogic.NotEnoughCurrencyLogic;
using InfoCanvasLogic.PurchaseConfirmLogic;
using PurchaseLogic.PurchaseProcessLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace PurchaseLogic.PurchaseHandlerLogic
{
    public enum PurchaseResultType
    {
        None,
        Complete,
        Cancel,
        Failure
    }
    
    public class PurchaseHandler : IPurchaseHandler, IDisposable
    {
        public ReactiveCommand<PurchaseResultType> OnPurchaseFinished { get; }

        private ICurrencyHandler _currencyHandler;
        private IPurchaseProcess _purchaseProcess;
        
        private CompositeDisposable _disposable;
        
        public PurchaseHandler(DiContainer container)
        {
            _currencyHandler = container.Resolve<ICurrencyHandler>();
            _purchaseProcess = container.Resolve<IPurchaseProcess>();

            OnPurchaseFinished = new ReactiveCommand<PurchaseResultType>();
            _disposable = new CompositeDisposable();
        }

        public void Setup()
        {
            _purchaseProcess.OnFinished.Subscribe((result) => FinishPurchase(result)).AddTo(_disposable);
        }

        public void Process(int price)
        {
            if (price <= 0)
            {
                FinishPurchase(PurchaseResultType.Complete);
            }
            else
            {
                if (_currencyHandler.Amount.Value >= price)
                {
                    _purchaseProcess.Start(PurchaseProcessType.Confirm);
                }
                else
                {
                    _purchaseProcess.Start(PurchaseProcessType.NotEnoughCurrency);
                }   
            }
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void FinishPurchase(PurchaseResultType resultType)
        {
            OnPurchaseFinished.Execute(resultType);
        }
    }
}