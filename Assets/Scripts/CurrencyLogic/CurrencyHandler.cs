using UniRx;

namespace CurrencyLogic
{
    public class CurrencyHandler : ICurrencyHandler
    {
        public ReactiveProperty<int> Amount { get; }

        private CurrencyData _data;
        
        public CurrencyHandler(CurrencyData data)
        {
            _data = data;
            
            Amount = new ReactiveProperty<int>();
            Amount.Value = _data.Amount;
        }
        
        public void Increase(int amount)
        {
            if (amount < 0) return;
            
            Amount.Value += amount;
            SetDataAmount(Amount.Value);
        }
        
        public void Decrease(int amount)
        {
            if (amount < 0) return;

            if (Amount.Value < amount) return;

            Amount.Value -= amount;
            SetDataAmount(Amount.Value);
        }

        private void SetDataAmount(int amount) => _data.SetAmount(amount);
    }
}