using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;

namespace PurchaseLogic.PurchaseProcessLogic
{
    public interface IPurchaseProcess
    {
        ReactiveCommand<PurchaseProcessType> OnStarted { get; }
        ReactiveCommand OnResultReceived { get; }
        ReactiveCommand<PurchaseResultType> OnFinished { get; }
        void Start(PurchaseProcessType purchaseProcessType);
        void SetResult(PurchaseResultType resultType);
        void Finish();
    }
}