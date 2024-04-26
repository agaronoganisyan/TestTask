using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace OffersLogic.OffersViewLogic
{
    public class OfferWithIconAndDescriptionView : OfferView
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _description;

        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithIconAndDescriptionModel localModel = (OfferWithIconAndDescriptionModel)offerViewModel.Model;

            _icon.sprite = localModel.Sprite;
            _description.text = localModel.Description;
        }
    }
}