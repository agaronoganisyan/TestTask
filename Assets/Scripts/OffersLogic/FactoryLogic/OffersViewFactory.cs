using Cysharp.Threading.Tasks;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OffersViewFactory : IOffersViewFactory
    {
        public ReactiveCommand OnSetuped { get; private set; }
        public bool IsSetuped { get; private set; }
        
        private OffersWithDescriptionFactory _offersWithDescriptionFactory;
        private OfferWithDoubleDescriptionFactory _offerWithDoubleDescriptionFactory;
        private OfferWithDoubleIconFactory _offerWithDoubleIconFactory;
        private OfferWithIconAndDescriptionFactory _offerWithIconAndDescriptionFactory;
        private OfferWithIconFactory _offerWithIconFactory;
        private OfferWithMoneyFactory _offerWithMoneyFactory;

        public OffersViewFactory(DiContainer container)
        {
            _offersWithDescriptionFactory = container.Resolve<OffersWithDescriptionFactory>();
            _offerWithDoubleDescriptionFactory = container.Resolve<OfferWithDoubleDescriptionFactory>();
            _offerWithDoubleIconFactory = container.Resolve<OfferWithDoubleIconFactory>();
            _offerWithIconAndDescriptionFactory = container.Resolve<OfferWithIconAndDescriptionFactory>();
            _offerWithIconFactory = container.Resolve<OfferWithIconFactory>();
            _offerWithMoneyFactory = container.Resolve<OfferWithMoneyFactory>();

            OnSetuped = new ReactiveCommand();
        }

        public async UniTask Setup()
        {
            await _offersWithDescriptionFactory.Setup();
            await _offerWithDoubleDescriptionFactory.Setup();
            await _offerWithDoubleIconFactory.Setup();
            await _offerWithIconAndDescriptionFactory.Setup();
            await _offerWithIconFactory.Setup();
            await _offerWithMoneyFactory.Setup();

            SetAsSetuped();
        }

        public OfferView Get(OfferHandler offerHandler)
        {
            switch (offerHandler.Data.Type())
            {
                case OfferType.OfferWithDescription:
                    return _offersWithDescriptionFactory.Get(offerHandler);
                case OfferType.OfferWithDoubleDescription:
                    return _offerWithDoubleDescriptionFactory.Get(offerHandler);
                case OfferType.OfferWithDoubleIcon:
                    return _offerWithDoubleIconFactory.Get(offerHandler);
                case OfferType.OfferWithIconAndDescription:
                    return _offerWithIconAndDescriptionFactory.Get(offerHandler);
                case OfferType.OfferWithIcon:
                    return _offerWithIconFactory.Get(offerHandler);
                case OfferType.OfferWithMoney:
                    return _offerWithMoneyFactory.Get(offerHandler);
                default:
                    return null;
            }
        }

        private void SetAsSetuped()
        {
            IsSetuped = true;
            OnSetuped.Execute();
        }
    }
}