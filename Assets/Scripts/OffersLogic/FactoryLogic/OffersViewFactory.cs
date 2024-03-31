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

        public OfferView Get(OfferViewModel offerViewModel)
        {
            switch (offerViewModel.Model.Type())
            {
                case OfferType.OfferWithDescription:
                    return _offersWithDescriptionFactory.Get(offerViewModel);
                case OfferType.OfferWithDoubleDescription:
                    return _offerWithDoubleDescriptionFactory.Get(offerViewModel);
                case OfferType.OfferWithDoubleIcon:
                    return _offerWithDoubleIconFactory.Get(offerViewModel);
                case OfferType.OfferWithIconAndDescription:
                    return _offerWithIconAndDescriptionFactory.Get(offerViewModel);
                case OfferType.OfferWithIcon:
                    return _offerWithIconFactory.Get(offerViewModel);
                case OfferType.OfferWithMoney:
                    return _offerWithMoneyFactory.Get(offerViewModel);
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