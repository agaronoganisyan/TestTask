using PurchaseLogic.PurchaseHandlerLogic;
using UniRx;

namespace InfoCanvasLogic.PurchaseConfirmLogic
{
    public interface IPurchaseConfirmSystem
    {
        ReactiveCommand OnStarted { get; }
        ReactiveCommand<PurchaseResult> OnFinished { get; }
        void Start();
        void SetResult(PurchaseResult result);
        void Finish();
    }
}