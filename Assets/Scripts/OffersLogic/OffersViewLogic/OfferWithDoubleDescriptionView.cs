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

        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithDoubleDescriptionModel localModel = (OfferWithDoubleDescriptionModel)offerViewModel.Model;

            _description_1.text = localModel.Description_1;
            _description_2.text = localModel.Description_2;
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