using System;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using PoolLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace OffersLogic.OffersViewLogic
{
    public class OfferWithDoubleIconView : OfferView, IPoolable<OfferWithDoubleIconView>
    {
        private Action<OfferWithDoubleIconView> _returnToPool;
        
        [SerializeField] private Image _icon_1;
        [SerializeField] private Image _icon_2;
        
        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithDoubleIconModel localModel = (OfferWithDoubleIconModel)offerViewModel.Model;

            _icon_1.sprite = localModel.Icon_1;
            _icon_2.sprite = localModel.Icon_2;

        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<OfferWithDoubleIconView> returnAction)
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