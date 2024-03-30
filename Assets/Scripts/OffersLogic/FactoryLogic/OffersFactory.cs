using Cysharp.Threading.Tasks;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OffersFactory : IOffersFactory
    {
        public ReactiveCommand OnSetuped { get; private set; }
        public bool IsSetuped { get; private set; }
        
        private OffersWithDescriptionFactory _offersWithDescriptionFactory;
        
        public OffersFactory(DiContainer container)
        {
            _offersWithDescriptionFactory = container.Resolve<OffersWithDescriptionFactory>();

            OnSetuped = new ReactiveCommand();
        }

        public async UniTask Setup()
        {
            await _offersWithDescriptionFactory.Setup();

            SetAsSetuped();
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

        private void SetAsSetuped()
        {
            IsSetuped = true;
            OnSetuped.Execute();
        }
    }
}