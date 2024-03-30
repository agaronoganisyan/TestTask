using System;
using OffersLogic.OffersDataLogic;
using PoolLogic;
using TMPro;
using UnityEngine;


namespace OffersLogic.OffersViewLogic
{
    public class OfferWithDoubleDescriptionView : OfferView, IPoolable<OfferWithDoubleDescriptionView>
    {
        private Action<OfferWithDoubleDescriptionView> _returnToPool;
        
        [SerializeField] private TextMeshProUGUI _description_1;
        [SerializeField] private TextMeshProUGUI _description_2;

        public override void Setup(OfferData data)
        {
            base.Setup(data);
            
            OfferWithDoubleDescriptionData localData = (OfferWithDoubleDescriptionData)data;

            _description_1.text = localData.Description_1;
            _description_2.text = localData.Description_2;
        }
        
        #region POOL_LOGIC
        
        public void PoolInitialize(Action<OfferWithDoubleDescriptionView> returnAction)
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