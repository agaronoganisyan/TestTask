using System;
using UnityEngine;

namespace CurrencyLogic
{
    [Serializable]
    public class CurrencyData : MonoBehaviour
    {
    [field: SerializeField] public int Amount { get; private set; }
    }
}