using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    [System.Serializable]
    public class OfferWithMoneyData : OfferData
    {
        [field: SerializeField] public int Value { get; private set; }
        public override OfferType Type()
        {
            return OfferType.OfferWithMoney;
        }

        public override int GetPrice()
        {
            return 0;
        }
    }
}