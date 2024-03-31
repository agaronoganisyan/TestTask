using OffersLogic.OffersDataLogic;
using Zenject;

namespace OffersLogic.OfferHandlerLogic
{
    public class OfferWithMoneyHandler : OfferHandler
    {
        public OfferWithMoneyHandler(DiContainer container) : base(container)
        {
        }

        protected override void Execute()
        {
            base.Execute();
            
            OfferWithMoneyData localData = (OfferWithMoneyData)Data;
            _currencyHandler.Increase(localData.Value); 
        }
    }
}