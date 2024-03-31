using UniRx;

namespace CurrencyLogic
{
    public interface ICurrencyViewModel
    {
        ReactiveProperty<int> Amount { get; }
        void Setup();
        void Increase(int amount);
        void Decrease(int amount);
    }
}