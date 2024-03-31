using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    [System.Serializable]
    public class OfferWithDoubleIconModel : OfferModel
    {
        [field: SerializeField] public Sprite Icon_1 { get; private set; }
        [field: SerializeField] public Sprite Icon_2 { get; private set; }
        
        [field: SerializeField] public int Price { get; private set; }
        public override OfferType Type()
        {
            return OfferType.OfferWithDoubleIcon;
        }

        public override int GetPrice()
        {
            return Price;
        }
    }
}