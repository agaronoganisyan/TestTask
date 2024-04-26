using OffersLogic.OffersViewLogic;
using Zenject;


namespace OffersLogic.FactoryLogic
{
    public class OfferWithIconAndDescriptionFactory : OfferViewFactory<OfferView>
    {
        public OfferWithIconAndDescriptionFactory(DiContainer container) : base(container)
        {
        }

        protected override string FactoryConfigAddress()
        {
            return "OfferWithIconAndDescriptionFactoryConfig";
        }
    }
}