using Cysharp.Threading.Tasks;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;

namespace OffersLogic.FactoryLogic
{
    public interface IOffersFactory
    {
        UniTask Setup();
        OfferView Get(OfferData offerData);
    }
}