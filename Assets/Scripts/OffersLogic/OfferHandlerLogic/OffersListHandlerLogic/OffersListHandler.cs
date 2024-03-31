using OffersLogic.OfferHandlerLogic.FactoryLogic;
using OffersLogic.OffersDataLogic;
using UniRx;
using Zenject;

namespace OffersLogic.OfferHandlerLogic.OffersListHandlerLogic
{
    public class OffersListHandler : IOffersListHandler
    {
        public ReactiveCollection<OfferHandler> Offers { get; }

        private OffersData _data;
        private IOfferHandlerFactory _offerHandlerFactory;
        
        public OffersListHandler(DiContainer container)
        {
            _data = container.Resolve<OffersData>();
            _offerHandlerFactory = container.Resolve<IOfferHandlerFactory>();
            
            Offers = new ReactiveCollection<OfferHandler>();
        }

        public void Setup()
        {
            for (int i = 0; i < _data.OffersList.Count; i++)
            {
                Offers.Add(_offerHandlerFactory.Get(_data.OffersList[i]));
            }
        }

        public void Remove(OfferHandler offerData)
        {
            if (!Offers.Contains(offerData)) return;

            Offers.Remove(offerData);
        }
    }
}