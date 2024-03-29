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
    public class OfferData
    {
        [field: SerializeField] public OfferType OfferType { get; private set; }
        
    }
    
    [System.Serializable]
    public class OfferWithDescriptionData : OfferData
    {
        [field: SerializeField] public string Description { get; private set; }
    }
    
    [System.Serializable]
    public class OfferWithDescriptionAndIconData : OfferData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
    }
    
    [System.Serializable]
    public class OfferWithIconData : OfferData
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}