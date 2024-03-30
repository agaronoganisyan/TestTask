using System;
using PurchaseLogic.PurchaseProcessLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace InfoCanvasLogic.PurchaseProcessLogic
{
    public class PurchaseProcessPanel : MonoBehaviour, IDisposable
    {
        private IPurchaseProcess _purchaseProcess;
        
        private CompositeDisposable _disposable;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _purchaseProcess = container.Resolve<IPurchaseProcess>();

            _disposable = new CompositeDisposable();
        }
        
        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _purchaseProcess.OnStarted.Subscribe((type) => Show()).AddTo(_disposable);
            _purchaseProcess.OnResultReceived.Subscribe((type) => Hide()).AddTo(_disposable);

            gameObject.SetActive(false);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            
            _purchaseProcess.Finish();
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}