namespace OffersLogic.OffersDataLogic
{
    public enum OfferType
    {
        None,
        OfferWithDescription,
        OfferWithIcon,
        OfferWithIconAndDescription,
        OfferWithMoney,
        OfferWithDoubleIcon,
        OfferWithDoubleDescription
    }
    
    [System.Serializable]
    public abstract class OfferModel
    {
        public abstract OfferType Type();
        public abstract int GetPrice();
    }
}