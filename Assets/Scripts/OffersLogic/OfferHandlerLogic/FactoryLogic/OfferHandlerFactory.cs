using OffersLogic.OffersDataLogic;
using Zenject;

namespace OffersLogic.OfferHandlerLogic.FactoryLogic
{
    public class OfferHandlerFactory : IOfferHandlerFactory
    {
        private DiContainer _container;
        
        public OfferHandlerFactory(DiContainer container)
        {
            _container = container;
        }

        public OfferHandler Get(OfferData offerData)
        {
            switch (offerData.Type())
            {
                case OfferType.OfferWithDescription:
                    return _container.Resolve<OfferWithDescriptionHandler>().Setup(offerData);
                case OfferType.OfferWithDoubleDescription:
                    return _container.Resolve<OfferWithDoubleDescriptionHandler>().Setup(offerData);
                case OfferType.OfferWithDoubleIcon:
                    return _container.Resolve<OfferWithDoubleIconHandler>().Setup(offerData);
                case OfferType.OfferWithIconAndDescription:
                    return _container.Resolve<OfferWithIconAndDescriptionHandler>().Setup(offerData);
                case OfferType.OfferWithIcon:
                    return _container.Resolve<OfferWithIconHandler>().Setup(offerData);
                case OfferType.OfferWithMoney:
                    return _container.Resolve<OfferWithMoneyHandler>().Setup(offerData);
                default:
                    return null;
            }
        }
    }
}