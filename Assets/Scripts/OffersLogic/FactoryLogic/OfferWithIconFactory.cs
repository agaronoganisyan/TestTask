using OffersLogic.OffersViewLogic;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OfferWithIconFactory : OfferViewFactory<OfferView>
    {
        public OfferWithIconFactory(DiContainer container) : base(container)
        {
        }

        protected override string FactoryConfigAddress()
        {
            return "OfferWithIconFactoryConfig";
        }
    }
}