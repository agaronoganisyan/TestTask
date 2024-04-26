using System;
using System.Linq;
using OffersLogic.OfferHandlerLogic.FactoryLogic;
using OffersLogic.OffersDataLogic;
using UniRx;
using Zenject;

namespace OffersLogic.OfferHandlerLogic.OffersListHandlerLogic
{
    public class OffersListViewModel : IOffersListViewModel, IDisposable
    {
        public ReactiveCommand<OfferViewModel> OfferRemoved { get; }
        public IReadOnlyReactiveCollection<OfferViewModel> Offers => _offers;
        private ReactiveCollection<OfferViewModel> _offers;

        private OffersModel _model;
        private IOfferViewModelFactory _offerViewModelFactory;

        private CompositeDisposable _disposable;
        
        public OffersListViewModel(DiContainer container)
        {
            _model = container.Resolve<OffersModel>();
            _offerViewModelFactory = container.Resolve<IOfferViewModelFactory>();
            
            _offers = new ReactiveCollection<OfferViewModel>();
            OfferRemoved = new ReactiveCommand<OfferViewModel>();
            _disposable = new CompositeDisposable();
        }

        public void Setup()
        {
            _model.Offers.ObserveRemove().Subscribe((value) => RemoveOffer(value.Value)).AddTo(_disposable);
            
            for (int i = 0; i < _model.Offers.Count; i++)
            {
                _offers.Add(_offerViewModelFactory.Get(_model.Offers[i]));
                _offers[i].SetIndex(i+1);
            }
        }

        public void Remove(OfferModel offerModel)
        {
            if (!_model.Offers.Contains(offerModel)) return;

            _model.Remove(offerModel);
        }

        private void RemoveOffer(OfferModel model)
        {
            for (int i = 0; i < _offers.Count; i++)
            {
                if (_offers[i].Model == model)
                {
                    OfferViewModel offerViewModel = _offers[i];
                    offerViewModel.ReturnToPool();
                    _offers.Remove(offerViewModel);
                    OfferRemoved.Execute(offerViewModel);
                    break;
                }
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}