using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    [System.Serializable]
    public class OfferWithIconAndDescriptionData : OfferData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        
        [field: SerializeField] public int Price { get; private set; }

        public override OfferType Type()
        {
            return OfferType.OfferWithIconAndDescription;
        }

        public override int GetPrice()
        {
            return Price;
        }
    }
}