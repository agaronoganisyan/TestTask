using InfoCanvasLogic.PurchaseProcessLogic;
using PurchaseLogic.PurchaseHandlerLogic;

namespace InfoCanvasLogic.NotEnoughCurrencyLogic
{
    public class NotEnoughCurrencyWindow : PurchaseProcessWindow
    {
        public void OnOk()
        {
            SetResult(PurchaseResultType.Failure);
        }
    }
}