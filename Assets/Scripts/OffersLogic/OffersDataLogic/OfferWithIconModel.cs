using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    [System.Serializable]
    public class OfferWithIconModel : OfferModel
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        
        [field: SerializeField] public int Price { get; private set; }

        public override OfferType Type()
        {
            return OfferType.OfferWithIcon;
        }

        public override int GetPrice()
        {
            return Price;
        }
    }
}