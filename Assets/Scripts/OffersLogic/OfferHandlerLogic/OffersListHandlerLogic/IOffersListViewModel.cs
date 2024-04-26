using System;
using OffersLogic.OffersDataLogic;
using UniRx;

namespace OffersLogic.OfferHandlerLogic.OffersListHandlerLogic
{
    public interface IOffersListViewModel
    {
        ReactiveCommand<OfferViewModel> OfferRemoved { get; }
        IReadOnlyReactiveCollection<OfferViewModel> Offers { get; }
        void Setup();
        void Remove(OfferModel offerData);
    }
}