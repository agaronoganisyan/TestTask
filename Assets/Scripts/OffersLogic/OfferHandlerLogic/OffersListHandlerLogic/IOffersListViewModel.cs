using OffersLogic.OffersDataLogic;
using UniRx;

namespace OffersLogic.OfferHandlerLogic.OffersListHandlerLogic
{
    public interface IOffersListViewModel
    {
        ReactiveCollection<OfferViewModel> Offers { get; }
        void Setup();
        void Remove(OfferModel offerData);
    }
}