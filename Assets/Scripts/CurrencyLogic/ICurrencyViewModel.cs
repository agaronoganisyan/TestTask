using UniRx;

namespace CurrencyLogic
{
    public interface ICurrencyViewModel
    {
        IReadOnlyReactiveProperty<int> Amount { get; }
        void Setup();
        void Increase(int amount);
        void Decrease(int amount);
    }
}