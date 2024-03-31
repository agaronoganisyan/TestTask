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
    public class OffersListView : MonoBehaviour
    {
        private IOffersListHandler _offersListHandler;
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

        private List<OfferView> _offers = new List<OfferView>();
        private Dictionary<OfferHandler, OfferView> _offerViewPairs = new Dictionary<OfferHandler, OfferView>();
        private int _numItems = 0;

        [Inject]
        private void Construct(DiContainer container)
        {
            _offersListHandler = container.Resolve<IOffersListHandler>();
            _offersViewFactory = container.Resolve<IOffersViewFactory>();
            
            _disposable = new CompositeDisposable();
        }

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _offersListHandler.Offers.ObserveRemove().Subscribe((offer) => OfferRemoved(offer)).AddTo(_disposable);

            if (_offersViewFactory.IsSetuped) CreateOffers(_offersListHandler.Offers);
            else _offersViewFactory.OnSetuped.Subscribe((value) => CreateOffers(_offersListHandler.Offers)).AddTo(_disposable);
        }

        private void CreateOffers(ReactiveCollection<OfferHandler> offers)
        {
            int offersAmount = offers.Count;

            _container.sizeDelta = new Vector2(_container.sizeDelta.x, PrefabSize * offersAmount);

            _numVisible = Mathf.CeilToInt(_maskRT.rect.size.y / PrefabSize);
            _numItems = offersAmount;
            
            for (int i = 0; i < _numItems; i++)
            {
                OfferView offer = _offersViewFactory.Get(offers[i]);
                
                offer.SetParentAndPosition(_container.transform,i+1,GetPositionByIndex(i));
                
                _offers.Add(offer);
                _offerViewPairs.Add(offers[i], offer);
            }
            
            _container.anchoredPosition = new Vector3(-_container.sizeDelta.x/2,0);
        }
        
        private void OfferRemoved(CollectionRemoveEvent<OfferHandler> offer)
        {
            if (!_offerViewPairs.ContainsKey(offer.Value)) return;

            OfferView offerToRemove = _offerViewPairs[offer.Value];
            
            int startIndex = offerToRemove.Index;

            for (int i = startIndex; i < _offerViewPairs.Count; i++)  
            {
                _offers[i].SetPosition(i, GetPositionByIndex(i-1));
            }

            Vector2 sizeDelta = _container.sizeDelta;
            sizeDelta = new Vector2(sizeDelta.x, sizeDelta.y - PrefabSize);
            _container.sizeDelta = sizeDelta;

            offerToRemove.ReturnToPool();
            _offers.Remove(offerToRemove);
            _offerViewPairs.Remove(offer.Value);
            _numItems--;
        }

        private Vector2 GetPositionByIndex(int index)
        {
            return _startPos + _offsetVec * index * PrefabSize - _offerPrefabHalfSize;
        }
    }
}