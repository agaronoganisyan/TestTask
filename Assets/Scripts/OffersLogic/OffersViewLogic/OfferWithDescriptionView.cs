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

        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);

            OfferWithDescriptionModel localModel = (OfferWithDescriptionModel)offerViewModel.Model;
            
            _description.text = localModel.Description;
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