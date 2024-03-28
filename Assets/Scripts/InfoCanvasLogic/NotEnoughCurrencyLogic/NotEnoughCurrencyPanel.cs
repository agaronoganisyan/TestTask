using UniRx;
using UnityEngine;
using Zenject;

namespace InfoCanvasLogic.NotEnoughCurrencyLogic
{
    public class NotEnoughCurrencyPanel : MonoBehaviour
    {
        private INotEnoughCurrencySystem _notEnoughCurrencySystem;

        private CompositeDisposable _disposable;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _notEnoughCurrencySystem = container.Resolve<INotEnoughCurrencySystem>();
        }
        
        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _notEnoughCurrencySystem.OnStarted.Subscribe((value) => Show()).AddTo(_disposable);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }
        
        private void Hide()
        {
            _notEnoughCurrencySystem.Finish();
            gameObject.SetActive(false);
        }
    }
}