using System;
using PoolLogic;
using TMPro;
using UnityEngine;

namespace OffersLogic.OffersViewLogic
{
    public class OfferWithDescriptionView : OfferView, IPoolable<OfferWithDescriptionView>
    {
        private Action<OfferWithDescriptionView> _returnToPool;
        
        [SerializeField] private TextMeshProUGUI _description;

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