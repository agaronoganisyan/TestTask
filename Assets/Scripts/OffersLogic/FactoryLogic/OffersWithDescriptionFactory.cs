using OffersLogic.OffersViewLogic;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OffersWithDescriptionFactory : OfferViewFactory<OfferView>
    {
        public OffersWithDescriptionFactory(DiContainer container) : base(container)
        {
        }

        protected override string FactoryConfigAddress()
        {
            return "OfferWithDescriptionFactoryConfig";
        }
    }
}