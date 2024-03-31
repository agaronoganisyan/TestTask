using System;
using System.Collections.Generic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic.PurchaseButtonLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace CurrencyLogic
{
    [Serializable]
    public class CurrencyModel : MonoBehaviour
    {
        [field: SerializeField] public ReactiveProperty<int> Amount { get; private set; }
        
        public void SetAmount(int amount) => Amount.Value = amount;
    }
}