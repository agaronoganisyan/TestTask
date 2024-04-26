using OffersLogic.OffersViewLogic;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OfferWithDoubleIconFactory : OfferViewFactory<OfferView>
    {
        public OfferWithDoubleIconFactory(DiContainer container) : base(container)
        {
        }

        protected override string FactoryConfigAddress()
        {
            return "OfferWithDoubleIconFactoryConfig";
        }
    }
}