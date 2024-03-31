using System;
using System;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using PoolLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithIconView : OfferView, IPoolable<OfferWithIconView>
    {
        private Action<OfferWithIconView> _returnToPool;
        
        [SerializeField] private Image _icon;
        
        public override void Setup(OfferHandler offerHandler)
        {
            base.Setup(offerHandler);
            
            OfferWithIconData localData = (OfferWithIconData)offerHandler.Data;

            _icon.sprite = localData.Sprite;
        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<OfferWithIconView> returnAction)
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