using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    public class OffersData : MonoBehaviour
    {
        [field: SerializeField] public OfferWithDescriptionData[] Offers { get; private set; }
    }
    
    public enum OfferType
    {
        None,
        OfferWithDescription,
        OfferWithIcon,
        OfferWithDescriptionAndIcon
    }

    [System.Serializable]
    public abstract class OfferData
    {
        [field: SerializeField] public OfferType OfferType { get; private set; }

        public abstract int GetPrice();
    }
    
    [System.Serializable]
    public class OfferWithDescriptionData : OfferData
    {
        [field: SerializeField] public string Description { get; private set; }
        
        [field: SerializeField] public int Price { get; private set; }
        
        public override int GetPrice()
        {
            return Price;
        }
    }
    
    [System.Serializable]
    public class OfferWithDescriptionAndIconData : OfferData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        
        [field: SerializeField] public int Price { get; private set; }

        public override int GetPrice()
        {
            return Price;
        }
    }
    
    [System.Serializable]
    public class OfferWithIconData : OfferData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        
        [field: SerializeField] public int Price { get; private set; }

        public override int GetPrice()
        {
            return Price;
        }
    }
    
    [System.Serializable]
    public class OfferWithMoney : OfferWithDescriptionData // ЕСЛИ НАСЛЕДОВАТЬСЯ ОТ ЭТОГО, ТО У ТЕБЯ БУДЕТ ПОЛЕ С ЦЕНОЙ КАК БЫ
    {
        public override int GetPrice()
        {
            return 0;
        }
    }
}