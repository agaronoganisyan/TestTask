using UniRx;

namespace PurchaseLogic.PurchaseHandlerLogic
{
    public interface IPurchaseHandler
    {
        ReactiveCommand<PurchaseResultType> OnPurchaseFinished { get; }
        void Process(int price);
    }
}