using System.Linq;
using OffersLogic.OfferHandlerLogic.FactoryLogic;
using OffersLogic.OffersDataLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.OfferHandlerLogic.OffersListHandlerLogic
{
    public class OffersListViewModel : IOffersListViewModel
    {
        public ReactiveCollection<OfferViewModel> Offers { get; }

        private OffersModel _model;
        private IOfferViewModelFactory _offerViewModelFactory;

        private CompositeDisposable _disposable;
        
        public OffersListViewModel(DiContainer container)
        {
            _model = container.Resolve<OffersModel>();
            _offerViewModelFactory = container.Resolve<IOfferViewModelFactory>();
            
            Offers = new ReactiveCollection<OfferViewModel>();
            _disposable = new CompositeDisposable();
        }

        public void Setup()
        {
            _model.Offers.ObserveRemove().Subscribe((value) => RemoveOffer(value.Value)).AddTo(_disposable);
            
            for (int i = 0; i < _model.Offers.Count; i++)
            {
                Offers.Add(_offerViewModelFactory.Get(_model.Offers[i]));
            }
        }

        public void Remove(OfferModel offerModel)
        {
            if (!_model.Offers.Contains(offerModel)) return;

            _model.Remove(offerModel);
        }

        private void RemoveOffer(OfferModel model)
        {
            for (int i = 0; i < Offers.Count; i++)
            {
                if (Offers[i].Model == model)
                {
                    Offers.RemoveAt(i);
                }
            }
        }
    }
}