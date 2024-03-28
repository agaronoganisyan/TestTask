using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace InfoCanvasLogic.PurchaseConfirmLogic
{
    public class PurchaseConfirmPanel : MonoBehaviour
    {
        private IPurchaseConfirmSystem _purchaseConfirmSystem;
        
        private CompositeDisposable _disposable;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _purchaseConfirmSystem = container.Resolve<IPurchaseConfirmSystem>();
        }

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _purchaseConfirmSystem.OnStarted.Subscribe((value) => Show()).AddTo(_disposable);
        }
        
        private void Show()
        {
            gameObject.SetActive(true);
        }
        
        private void Hide()
        {
            _purchaseConfirmSystem.Finish();
            gameObject.SetActive(false);
        }
    }
}