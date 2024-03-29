using OffersLogic.OffersViewLogic;
using UnityEngine;

namespace OffersLogic.FactoryLogic.ConfigLogic
{
    [CreateAssetMenu (fileName = "OfferFactoryConfig", menuName = "Configs/New OfferFactoryConfig")]
    public class OfferFactoryConfig : ScriptableObject
    {
        [field: SerializeField] public int InitialPoolSize { get; private set; }
        [field: SerializeField] public OfferView Prefab { get; private set; }
    }
}