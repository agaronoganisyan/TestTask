using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using UnityEngine;
using UnityEngine.UI;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithIconView : OfferView
    {
        [SerializeField] private Image _icon;
        
        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithIconModel localModel = (OfferWithIconModel)offerViewModel.Model;

            _icon.sprite = localModel.Sprite;
        }
    }
}