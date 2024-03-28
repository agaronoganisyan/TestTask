using System;
using UnityEngine;

namespace CurrencyLogic
{
    [Serializable]
    public class CurrencyData
    {
    [field: SerializeField] public int Amount { get; private set; }
    }
}