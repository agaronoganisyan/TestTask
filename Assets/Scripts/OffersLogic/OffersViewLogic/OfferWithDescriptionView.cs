using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using TMPro;
using UnityEngine;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithDescriptionView : OfferView
    {
        [SerializeField] private TextMeshProUGUI _description;

        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);

            OfferWithDescriptionModel localModel = (OfferWithDescriptionModel)offerViewModel.Model;
            
            _description.text = localModel.Description;
        }
    }
}