using System;
using OffersLogic.OfferHandlerLogic;
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

        public override void Setup(OfferHandler offerHandler)
        {
            base.Setup(offerHandler);
            
            OfferWithDoubleDescriptionData localData = (OfferWithDoubleDescriptionData)offerHandler.Data;

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