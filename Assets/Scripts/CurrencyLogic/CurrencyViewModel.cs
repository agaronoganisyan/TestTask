using UniRx;

namespace CurrencyLogic
{
    public class CurrencyViewModel : ICurrencyViewModel
    {
        public ReactiveProperty<int> Amount { get; }

        private CurrencyModel _model;

        private CompositeDisposable _disposable;
        
        public CurrencyViewModel(CurrencyModel model)
        {
            _model = model;
            
            Amount = new ReactiveProperty<int>();
            _disposable = new CompositeDisposable();
        }

        public void Setup()
        {
            _model.Amount.Subscribe((value) => ChangeAmount(value)).AddTo(_disposable);
            ChangeAmount(_model.Amount.Value);
        }

        public void Increase(int amount)
        {
            if (amount < 0) return;
            
            _model.Amount.Value += amount;
        }
        
        public void Decrease(int amount)
        {
            if (amount < 0) return;

            if (_model.Amount.Value < amount) return;

            _model.Amount.Value -= amount;
        }

        private void ChangeAmount(int amount) => Amount.Value = amount;
    }
}