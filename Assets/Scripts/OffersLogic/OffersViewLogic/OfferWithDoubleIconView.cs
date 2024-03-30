using System;
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
        
        public override void Setup(OfferData data)
        {
            base.Setup(data);
            
            OfferWithDoubleIconData localData = (OfferWithDoubleIconData)data;

            _icon_1.sprite = localData.Icon_1;
            _icon_2.sprite = localData.Icon_2;

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