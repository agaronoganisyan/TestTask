using OffersLogic.OffersViewLogic;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OfferWithDoubleDescriptionFactory : OfferViewFactory<OfferView>
    {
        public OfferWithDoubleDescriptionFactory(DiContainer container) : base(container)
        {
        }

        protected override string FactoryConfigAddress()
        {
            return "OfferWithDoubleDescriptionFactoryConfig";
        }
    }
}