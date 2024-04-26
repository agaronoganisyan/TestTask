using System;
using System.Collections.Generic;
using OffersLogic.FactoryLogic;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OfferHandlerLogic.OffersListHandlerLogic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField] private Scrollbar _scrollbar;
        private const float Spacing = 20;
        private const float OfferSizeY = 90;
        private const float PrefabSize = OfferSizeY + Spacing;
        private readonly Vector3 _offerPrefabHalfSize = new Vector3(0, PrefabSize / 2,0);
        private readonly Vector3 _startPos = Vector2.zero;
        private readonly Vector3 _offsetVec = Vector3.down;

        private readonly int _numBuffer = 2;
        private int _numVisible;
        private int _numItems;
        private int _numAllItems;
        private int _previousOriginalIndex;
        
        private List<OfferViewModel> _pooledItems = new List<OfferViewModel>();
        
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
            _scrollbar.onValueChanged.AsObservable().Subscribe(ScrollRectWasMoved).AddTo(_disposable);
            
            _offersListViewModel.OfferRemoved.Subscribe((offer) => OfferRemoved(offer)).AddTo(_disposable);

            if (_offersViewFactory.IsSetuped) CreateOffers(_offersListViewModel.Offers);
            else _offersViewFactory.OnSetuped.Subscribe((value) => CreateOffers(_offersListViewModel.Offers)).AddTo(_disposable);
        }

        private void CreateOffers(IReadOnlyReactiveCollection<OfferViewModel> offers)
        {
            _numAllItems = offers.Count;

            _container.sizeDelta = new Vector2(_container.sizeDelta.x, PrefabSize * _numAllItems);

            _numVisible = Mathf.CeilToInt(_maskRT.rect.size.y / PrefabSize);
            
            _numItems = Mathf.Min(_numAllItems, _numVisible + _numBuffer);
            
            for (int i = 0; i < _numItems; i++)
            {
                _offersViewFactory.Get(offers[i]);
                
                offers[i].SetParentAndPosition(_container.transform,i + 1, GetPositionByIndex(i));
                
                AddItemToPool(offers[i]);
            }
            
            _container.anchoredPosition = new Vector3(-_container.sizeDelta.x/2,0);
            _previousOriginalIndex = 0;
        }
        
        private void OfferRemoved(OfferViewModel offer)
        {
            Vector2 containerSize = _container.sizeDelta;
            containerSize = new Vector2(containerSize.x, containerSize.y - PrefabSize);
            _container.sizeDelta = containerSize;

            _numAllItems--;
            RemoveItemFromPool(offer);
            ReorderItemsByPos(_scrollbar.value, true);
        }

        private void ScrollRectWasMoved(float normPos)
        {
            ReorderItemsByPos(normPos);
        }

        private void ReorderItemsByPos(float normPos, bool offerWasRemoved = false)
        {
            normPos = 1f - normPos;
            int numItemsBeyondTopBoundary = Mathf.FloorToInt(normPos * (_numAllItems - _numVisible));
            int originalIndex = numItemsBeyondTopBoundary < 0 ? 0 :numItemsBeyondTopBoundary;
            
            bool originalIndexChanged = originalIndex != _previousOriginalIndex ? true : false;
            if (originalIndexChanged) _previousOriginalIndex = originalIndex;

            int newIndex = originalIndex;

            if (!originalIndexChanged && !offerWasRemoved) return;
            
            RemoveAllItemFromPool();
            
            for (int i = 0; i < _numItems; i++)
            {
                if (newIndex >= _numAllItems) break;
                
                CreateItemByIndex(newIndex);

                newIndex++;
            }
        }

        private void CreateItemByIndex(int index)
        {
            OfferViewModel newOffer = _offersListViewModel.Offers[index];
            _offersViewFactory.Get(newOffer);
            newOffer.SetParentAndPosition(_container.transform, index + 1, GetPositionByIndex(index));
            AddItemToPool(newOffer);
        }

        private void AddItemToPool(OfferViewModel viewModel)
        {
            _pooledItems.Add(viewModel);
        }
        
        private void RemoveItemFromPool(OfferViewModel viewModel)
        {
            _pooledItems.Remove(viewModel);
        }

        private void RemoveAllItemFromPool()
        {
            for (int i = 0; i < _pooledItems.Count; i++)
            {
                _pooledItems[i].ReturnToPool();
            }
            
            _pooledItems.Clear();
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