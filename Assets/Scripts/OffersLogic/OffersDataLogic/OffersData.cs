using System.Collections.Generic;
using UnityEngine;

namespace OffersLogic.OffersDataLogic
{
    public class OffersData : MonoBehaviour
    {
        public IReadOnlyList<OfferData> OffersList => _offersList;
        [SerializeReference, SelectImplementation(typeof(OfferData))]
        private List<OfferData> _offersList = new List<OfferData>();

        public void Remove(OfferData offerData)
        {
            _offersList.Remove(offerData);
        }
    }
}