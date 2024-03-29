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
        }
        
        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _purchaseProcess.OnStarted.Subscribe((type) => ShowWindow(type)).AddTo(_disposable);
        }

        private void ShowWindow(PurchaseProcessType purchaseProcessType)
        {
            
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}