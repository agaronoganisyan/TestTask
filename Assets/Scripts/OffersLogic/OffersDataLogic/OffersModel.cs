using System.Collections.Generic;
using OffersLogic.OffersViewLogic.PurchaseButtonLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.OffersDataLogic
{
    public class OffersModel : MonoBehaviour
    {
        public IReadOnlyReactiveCollection<OfferModel> Offers => _offers;
        private ReactiveCollection<OfferModel> _offers; 
        
        [SerializeReference, SelectImplementation(typeof(OfferModel))]
        private List<OfferModel> _offersList = new List<OfferModel>();

        [Inject]
        private void Construct()
        {
            _offers = new ReactiveCollection<OfferModel>();
        }

        public void Setup()
        {
            for (int i = 0; i < _offersList.Count; i++)
            {
                _offers.Add(_offersList[i]);
            }
        }

        public void Remove(OfferModel offerModel)
        {
            _offers.Remove(offerModel);
            _offersList.Remove(offerModel);
        }
    }
}