using System;
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

        protected CompositeDisposable _disposable;
        
        [Inject]
        protected virtual void Construct(DiContainer container)
        {
            _purchaseProcess = container.Resolve<IPurchaseProcess>();

            _disposable = new CompositeDisposable();
        }

        public void Awake()
        {
            Setup();
        }
        
        public void Enter()
        {
            Show();
        }
        public void Exit()
        {
            Hide();
        }

        protected virtual void Setup()
        {
            gameObject.SetActive(false);
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
            // _purchaseProcess.Finish();
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}