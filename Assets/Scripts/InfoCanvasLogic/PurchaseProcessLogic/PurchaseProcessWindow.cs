using System;
using InfrastructureLogic.StateMachineLogic.Simple;
using PurchaseLogic.PurchaseHandlerLogic;
using PurchaseLogic.PurchaseProcessLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace InfoCanvasLogic.PurchaseProcessLogic
{
    public abstract class PurchaseProcessWindow : MonoBehaviour, IDisposable
    {
        private IPurchaseProcess _purchaseProcess;
        
        protected CompositeDisposable _disposable = new CompositeDisposable();
        
        [Inject]
        protected virtual void Construct(DiContainer container)
        {
            _purchaseProcess = container.Resolve<IPurchaseProcess>();
        }
        
        public void Update()
        {
        }
        public void Enter()
        {
            Show();
        }
        public void Exit()
        {
            Hide();
        }

        public virtual void Setup()
        {
            gameObject.SetActive(false);
            //_notEnoughCurrencySystem.OnStarted.Subscribe((value) => Show()).AddTo(_disposable);
        }

        protected void SetResult(PurchaseResultType purchaseResultType)
        {
            _purchaseProcess.SetResult(purchaseResultType);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }
        
        private void Hide()
        {
            _purchaseProcess.Finish();
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}