using System;
using InfoCanvasLogic.PurchaseProcessLogic;
using PurchaseLogic.PurchaseHandlerLogic;
using PurchaseLogic.PurchaseProcessLogic;
using UniRx;
using Zenject;

namespace InfoCanvasLogic.NotEnoughCurrencyLogic
{
    public class NotEnoughCurrencyWindow : PurchaseProcessWindow
    {
        private NotEnoughCurrencyState _state;
        
        [Inject]
        protected override void Construct(DiContainer container)
        {
            base.Construct(container);

            _state = container.Resolve<NotEnoughCurrencyState>();
        }

        
        public override void Setup()
        {
            base.Setup();

            _state.OnEntered.Subscribe((value) => Enter()).AddTo(_disposable);
            _state.OnExit.Subscribe((value) => Exit()).AddTo(_disposable);
        }
        
        public void OnOk()
        {
            SetResult(PurchaseResultType.Failure);
        }
    }
}