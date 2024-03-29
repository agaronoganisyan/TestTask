using Cysharp.Threading.Tasks;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OffersFactory : IOffersFactory
    {
        private OffersWithDescriptionFactory _offersWithDescriptionFactory;
        
        public OffersFactory(DiContainer container)
        {
            _offersWithDescriptionFactory = container.Resolve<OffersWithDescriptionFactory>();
        }

        public async UniTask Setup()
        {
            await _offersWithDescriptionFactory.Setup();
        }

        public OfferView Get(OfferData offerData)
        {
            switch (offerData.OfferType)
            {
                case OfferType.OfferWithDescription:
                    return GetOfferWithDescriptionView(offerData);
                default:
                    return null;
            }
        }

        private OfferWithDescriptionView GetOfferWithDescriptionView(OfferData data)
        {
            return _offersWithDescriptionFactory.Get(data);
        }
    }
}