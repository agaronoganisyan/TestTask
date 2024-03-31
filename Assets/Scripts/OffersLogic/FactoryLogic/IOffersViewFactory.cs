using Cysharp.Threading.Tasks;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using UniRx;

namespace OffersLogic.FactoryLogic
{
    public interface IOffersViewFactory
    {
        ReactiveCommand OnSetuped { get; }
        bool IsSetuped { get; }
        UniTask Setup();
        OfferView Get(OfferHandler offerHandler);
    }
}