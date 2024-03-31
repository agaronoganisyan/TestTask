using System;
using OffersLogic.OfferHandlerLogic;
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
        
        public override void Setup(OfferViewModel offerViewModel)
        {
            base.Setup(offerViewModel);
            
            OfferWithMoneyModel localModel = (OfferWithMoneyModel)offerViewModel.Model;

            _valueText.text = $"{localModel.Value}$";
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