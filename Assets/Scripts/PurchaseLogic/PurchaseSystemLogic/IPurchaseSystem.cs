using UniRx;

namespace PurchaseLogic.PurchaseSystemLogic
{
    public interface IPurchaseSystem
    {
        IPurchaseSystem OnCompleteCallback(ReactiveCommand callback);
        IPurchaseSystem OnCancelCallback(ReactiveCommand callback);
        IPurchaseSystem OnFailureCallback(ReactiveCommand callback);
        void Purchase(int price);
    }
}