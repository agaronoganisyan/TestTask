using OffersLogic.OffersDataLogic;
using Zenject;

namespace OffersLogic.OfferHandlerLogic.FactoryLogic
{
    public class OfferViewModelFactory : IOfferViewModelFactory
    {
        private DiContainer _container;
        
        public OfferViewModelFactory(DiContainer container)
        {
            _container = container;
        }

        public OfferViewModel Get(OfferModel offerModel)
        {
            switch (offerModel.Type())
            {
                case OfferType.OfferWithDescription:
                    return _container.Resolve<OfferWithDescriptionViewModel>().Setup(offerModel);
                case OfferType.OfferWithDoubleDescription:
                    return _container.Resolve<OfferWithDoubleDescriptionViewModel>().Setup(offerModel);
                case OfferType.OfferWithDoubleIcon:
                    return _container.Resolve<OfferWithDoubleIconViewModel>().Setup(offerModel);
                case OfferType.OfferWithIconAndDescription:
                    return _container.Resolve<OfferWithIconAndDescriptionViewModel>().Setup(offerModel);
                case OfferType.OfferWithIcon:
                    return _container.Resolve<OfferWithIconViewModel>().Setup(offerModel);
                case OfferType.OfferWithMoney:
                    return _container.Resolve<OfferWithMoneyViewModel>().Setup(offerModel);
                default:
                    return null;
            }
        }
    }
}