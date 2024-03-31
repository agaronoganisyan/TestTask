using OffersLogic.OffersDataLogic;

namespace OffersLogic.OfferHandlerLogic.FactoryLogic
{
    public interface IOfferViewModelFactory
    {
        OfferViewModel Get(OfferModel offerModel);
    }
}