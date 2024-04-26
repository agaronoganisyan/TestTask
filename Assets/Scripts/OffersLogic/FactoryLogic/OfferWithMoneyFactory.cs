using OffersLogic.OffersViewLogic;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OfferWithMoneyFactory : OfferViewFactory<OfferView>
    {
        public OfferWithMoneyFactory(DiContainer container) : base(container)
        {
        }

        protected override string FactoryConfigAddress()
        {
            return "OfferWithMoneyFactoryConfig";
        }
    }
}