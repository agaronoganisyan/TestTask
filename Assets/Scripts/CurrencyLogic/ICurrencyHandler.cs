using UniRx;

namespace CurrencyLogic
{
    public interface ICurrencyHandler
    {
        ReactiveProperty<int> Amount { get; }
        void Increase(int amount);
        void Decrease(int amount);
    }
}