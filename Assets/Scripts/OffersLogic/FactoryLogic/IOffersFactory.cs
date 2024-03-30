using Cysharp.Threading.Tasks;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using UniRx;

namespace OffersLogic.FactoryLogic
{
    public interface IOffersFactory
    {
        ReactiveCommand OnSetuped { get; }
        bool IsSetuped { get; }
        UniTask Setup();
        OfferView Get(OfferData offerData);
    }
}