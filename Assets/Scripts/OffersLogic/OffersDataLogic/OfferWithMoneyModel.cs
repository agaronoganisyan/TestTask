using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    [System.Serializable]
    public class OfferWithMoneyModel : OfferModel
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