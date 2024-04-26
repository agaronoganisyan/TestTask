using System;
using UniRx;
using UnityEngine;

namespace CurrencyLogic
{
    [Serializable]
    public class CurrencyModel : MonoBehaviour
    {

        public IReadOnlyReactiveProperty<int> Amount => _amount;
        [SerializeField] private ReactiveProperty<int> _amount;
        
        public void SetAmount(int amount) => _amount.Value = amount;
    }
}