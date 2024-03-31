using UniRx;

namespace OffersLogic.OfferHandlerLogic.OffersListHandlerLogic
{
    public interface IOffersListHandler
    {
        ReactiveCollection<OfferHandler> Offers { get; }
        void Setup();
        void Remove(OfferHandler offerData);
    }
}