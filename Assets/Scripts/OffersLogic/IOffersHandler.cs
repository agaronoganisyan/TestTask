using OffersLogic.OffersDataLogic;
using UniRx;

namespace OffersLogic
{
    public interface IOffersHandler
    {
        ReactiveCollection<OfferData> Offers { get; }
        void Remove(OfferData offerData);
    }
}