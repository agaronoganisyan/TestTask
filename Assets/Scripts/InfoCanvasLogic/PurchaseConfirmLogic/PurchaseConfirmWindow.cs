using InfoCanvasLogic.PurchaseProcessLogic;
using PurchaseLogic.PurchaseHandlerLogic;

namespace InfoCanvasLogic.PurchaseConfirmLogic
{
    public class PurchaseConfirmWindow : PurchaseProcessWindow
    {
        public void OnConfirm()
        {
            SetResult(PurchaseResultType.Complete);
        }

        public void OnCancel()
        {
            SetResult(PurchaseResultType.Cancel);
        }
    }
}