using System;
using UniRx;
using UnityEngine;

namespace CurrencyLogic
{
    public class CurrencyViewModel : ICurrencyViewModel, IDisposable
    {
        public IReadOnlyReactiveProperty<int> Amount => _amount;
        private IReactiveProperty<int> _amount;
        
        private CurrencyModel _model;

        private CompositeDisposable _disposable;
        
        public CurrencyViewModel(CurrencyModel model)
        {
            _model = model;
            
            _amount = new ReactiveProperty<int>();
            _disposable = new CompositeDisposable();
        }

        public void Setup()
        {
            _model.Amount.Subscribe((value) => ChangeAmount(value)).AddTo(_disposable);
            ChangeAmount(_model.Amount.Value);
        }

        public void Increase(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException();
            
            _model.SetAmount(_model.Amount.Value + amount);
        }
        
        public void Decrease(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException();

            if (_model.Amount.Value < amount) throw new ArgumentOutOfRangeException();

            _model.SetAmount(_model.Amount.Value - amount);
        }

        private void ChangeAmount(int amount) => _amount.Value = amount;

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}