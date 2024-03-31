using System;
using UniRx;
using UnityEngine;

namespace CurrencyLogic
{
    [Serializable]
    public class CurrencyModel : MonoBehaviour
    {
        [field: SerializeField] public ReactiveProperty<int> Amount { get; private set; }
        
        public void SetAmount(int amount) => Amount.Value = amount;
    }
}