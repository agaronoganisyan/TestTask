using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using TMPro;
using UnityEngine;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithMoneyView : OfferView
    {
        [SerializeField] private TextMeshProUGUI _valueText;
        
        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithMoneyModel localModel = (OfferWithMoneyModel)offerViewModel.Model;

            _valueText.text = $"{localModel.Value}$";
        }
    }
}