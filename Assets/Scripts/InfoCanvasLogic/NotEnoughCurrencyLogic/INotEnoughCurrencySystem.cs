using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;

namespace InfoCanvasLogic.NotEnoughCurrencyLogic
{
    public interface INotEnoughCurrencySystem
    {
        ReactiveCommand OnStarted { get; }
        public ReactiveCommand<PurchaseResult> OnFinished { get; }
        void Start();
        void Finish();
    }
}