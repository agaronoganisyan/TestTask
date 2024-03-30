using System;
using OffersLogic.OffersDataLogic;
using PoolLogic;
using TMPro;
using UnityEngine;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithMoneyView : OfferView, IPoolable<OfferWithMoneyView>
    {
        private Action<OfferWithMoneyView> _returnToPool;
        
        [SerializeField] private TextMeshProUGUI _valueText;
        
        public override void Setup(OfferData data)
        {
            base.Setup(data);
            
            OfferWithMoneyData localData = (OfferWithMoneyData)data;

            _valueText.text = $"{localData.Value}$";
        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<OfferWithMoneyView> returnAction)
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