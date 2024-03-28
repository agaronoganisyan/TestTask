using UniRx;

namespace PurchaseLogic.PurchaseHandlerLogic
{
    public interface IPurchaseHandler
    {
        ReactiveCommand<PurchaseResult> OnPurchaseFinished { get; }
        void Process(int price);
    }
}