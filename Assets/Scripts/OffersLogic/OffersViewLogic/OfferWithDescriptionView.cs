using System;
using PoolLogic;
using TMPro;
using UnityEngine;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithDescriptionView : OfferView, IPoolable<OfferWithDescriptionView>
    {
        private Action<OfferView> _returnToPool;
        
        [SerializeField] private TextMeshProUGUI _description;
        
        protected override void Execute()
        {
            
        }

        #region POOL_LOGIC
        
        public void PoolInitialize(Action<OfferWithDescriptionView> returnAction)
        {
            
        }
        
        public void ReturnToPool()
        {
            _returnToPool?.Invoke(this);
        }
        
        #endregion
    }
}