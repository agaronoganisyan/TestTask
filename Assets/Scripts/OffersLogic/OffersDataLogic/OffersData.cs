using System.Collections.Generic;
using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    public class OffersData : MonoBehaviour
    {
        [field: SerializeField] public OfferWithDescriptionData[] Offers { get; private set; }

        public IReadOnlyList<OfferData> OffersList => _offersList;
        [SerializeReference, SelectImplementation(typeof(OfferData))]
        private List<OfferData> _offersList = new List<OfferData>();
    }
}