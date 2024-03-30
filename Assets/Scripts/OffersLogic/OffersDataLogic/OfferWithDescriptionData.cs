using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    [System.Serializable]
    public class OfferWithDescriptionData : OfferData
    {
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int Price { get; private set; }

        public override OfferType Type()
        {
            return OfferType.OfferWithDescription;
        }

        public override int GetPrice()
        {
            return Price;
        }
    }
}