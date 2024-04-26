using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using TMPro;
using UnityEngine;


namespace OffersLogic.OffersViewLogic
{
    public class OfferWithDoubleDescriptionView : OfferView
    {
        [SerializeField] private TextMeshProUGUI _description_1;
        [SerializeField] private TextMeshProUGUI _description_2;

        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithDoubleDescriptionModel localModel = (OfferWithDoubleDescriptionModel)offerViewModel.Model;

            _description_1.text = localModel.Description_1;
            _description_2.text = localModel.Description_2;
        }
    }
}