using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;

namespace InfoCanvasLogic.NotEnoughCurrencyLogic
{
    public class NotEnoughCurrencySystem : INotEnoughCurrencySystem
    {
        public ReactiveCommand OnStarted { get; }
        public ReactiveCommand<PurchaseResult> OnFinished { get; }

        public NotEnoughCurrencySystem()
        {
            OnStarted = new ReactiveCommand();
            OnFinished = new ReactiveCommand<PurchaseResult>();
        }

        public void Start()
        {
            OnStarted?.Execute();
        }

        public void Finish()
        {
            OnFinished?.Execute(PurchaseResult.Failure);
        }
    }
}