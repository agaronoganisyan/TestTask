using PurchaseLogic.PurchaseHandlerLogic;
using PurchaseLogic.PurchaseProcessLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace InfoCanvasLogic.PurchaseProcessLogic
{
    public abstract class PurchaseProcessWindow : MonoBehaviour
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
    }
}