using OffersLogic.OffersDataLogic;
using Zenject;

namespace OffersLogic.OfferHandlerLogic
{
    public class OfferWithMoneyViewModel : OfferViewModel
    {
        public OfferWithMoneyViewModel(DiContainer container) : base(container)
        {
        }

        protected override void Execute()
        {
            base.Execute();
            
            OfferWithMoneyModel localModel = (OfferWithMoneyModel)Model;
            CurrencyViewModel.Increase(localModel.Value); 
        }
    }
}