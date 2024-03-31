using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    [System.Serializable]
    public class OfferWithDoubleDescriptionModel : OfferModel
    {
        [field: SerializeField] public string Description_1 { get; private set; }
        [field: SerializeField] public string Description_2 { get; private set; }
        
        [field: SerializeField] public int Price { get; private set; }
        
        public override OfferType Type()
        {
            return OfferType.OfferWithDoubleDescription;
        }

        public override int GetPrice()
        {
            return Price;
        }
    }
}