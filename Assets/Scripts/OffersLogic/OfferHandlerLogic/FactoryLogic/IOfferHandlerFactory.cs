using OffersLogic.OffersDataLogic;

namespace OffersLogic.OfferHandlerLogic.FactoryLogic
{
    public interface IOfferHandlerFactory
    {
        OfferHandler Get(OfferData offerData);
    }
}