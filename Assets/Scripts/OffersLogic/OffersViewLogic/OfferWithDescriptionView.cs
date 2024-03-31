using System;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using PoolLogic;
using TMPro;
using UnityEngine;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithDescriptionView : OfferView, IPoolable<OfferWithDescriptionView>
    {
        private Action<OfferWithDescriptionView> _returnToPool;
        
        [SerializeField] private TextMeshProUGUI _description;

        public override void Setup(OfferHandler offerHandler)
        {
            base.Setup(offerHandler);

            OfferWithDescriptionData localData = (OfferWithDescriptionData)offerHandler.Data;
            
            _description.text = localData.Description;
        }

        #region POOL_LOGIC
        
        public void PoolInitialize(Action<OfferWithDescriptionView> returnAction)
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