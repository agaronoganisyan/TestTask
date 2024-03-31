using System;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using PoolLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace OffersLogic.OffersViewLogic
{
    public class OfferWithIconAndDescriptionView : OfferView, IPoolable<OfferWithIconAndDescriptionView>
    {
        private Action<OfferWithIconAndDescriptionView> _returnToPool;
        
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _description;

        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithIconAndDescriptionModel localModel = (OfferWithIconAndDescriptionModel)offerViewModel.Model;

            _icon.sprite = localModel.Sprite;
            _description.text = localModel.Description;
        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<OfferWithIconAndDescriptionView> returnAction)
        {
            _returnToPool = returnAction;
        }
        
        public override void ReturnToPool()
        {
            _returnToPool?.Invoke(this);
        }
        
        #endregion
    }
}