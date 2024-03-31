using System;
using System.Collections.Generic;
using OffersLogic.FactoryLogic;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OfferHandlerLogic.OffersListHandlerLogic;
using OffersLogic.OffersViewLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.OffersListViewLogic
{
    public class OffersListView : MonoBehaviour, IDisposable
    {
        private IOffersListViewModel _offersListViewModel;
        private IOffersViewFactory _offersViewFactory;
        
        private CompositeDisposable _disposable;
        
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _maskRT;
        private const float Spacing = 20;
        private const float OfferSizeY = 90;
        private const float PrefabSize = OfferSizeY + Spacing;
        private readonly Vector3 _offerPrefabHalfSize = new Vector3(0, PrefabSize / 2,0);
        private readonly Vector3 _startPos = Vector2.zero;
        private readonly Vector3 _offsetVec = Vector3.down;

        private int _numVisible;
        
        private int _numItems = 0;

        [Inject]
        private void Construct(DiContainer container)
        {
            _offersListViewModel = container.Resolve<IOffersListViewModel>();
            _offersViewFactory = container.Resolve<IOffersViewFactory>();
            
            _disposable = new CompositeDisposable();
        }

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _offersListViewModel.Offers.ObserveRemove().Subscribe((offer) => OfferRemoved(offer)).AddTo(_disposable);

            if (_offersViewFactory.IsSetuped) CreateOffers(_offersListViewModel.Offers);
            else _offersViewFactory.OnSetuped.Subscribe((value) => CreateOffers(_offersListViewModel.Offers)).AddTo(_disposable);
        }

        private void CreateOffers(ReactiveCollection<OfferViewModel> offers)
        {
            int offersAmount = offers.Count;

            _container.sizeDelta = new Vector2(_container.sizeDelta.x, PrefabSize * offersAmount);

            _numVisible = Mathf.CeilToInt(_maskRT.rect.size.y / PrefabSize);
            _numItems = offersAmount;
            
            for (int i = 0; i < _numItems; i++)
            {
                _offersViewFactory.Get(offers[i]);
                
                offers[i].SetParentAndPosition(_container.transform,i+1,GetPositionByIndex(i));
            }
            
            _container.anchoredPosition = new Vector3(-_container.sizeDelta.x/2,0);
        }
        
        private void OfferRemoved(CollectionRemoveEvent<OfferViewModel> offer)
        {
            int startIndex = offer.Value.Index.Value-1;

            for (int i = startIndex; i < _offersListViewModel.Offers.Count; i++)  
            {
                _offersListViewModel.Offers[i].SetPosition(i+1, GetPositionByIndex(i));
            }

            Vector2 sizeDelta = _container.sizeDelta;
            sizeDelta = new Vector2(sizeDelta.x, sizeDelta.y - PrefabSize);
            _container.sizeDelta = sizeDelta;

            offer.Value.ReturnToPool();
            _numItems--;
        }

        private Vector2 GetPositionByIndex(int index)
        {
            return _startPos + _offsetVec * index * PrefabSize - _offerPrefabHalfSize;
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}