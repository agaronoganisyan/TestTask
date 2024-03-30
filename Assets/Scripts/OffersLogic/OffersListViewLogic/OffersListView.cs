using System.Collections.Generic;
using OffersLogic.FactoryLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using UniRx;
using UnityEngine;
using Zenject;

namespace OffersLogic.OffersListViewLogic
{
    public class OffersListView : MonoBehaviour
    {
        private IOffersHandler _offersHandler;
        private IOffersFactory _offersFactory;
        
        private CompositeDisposable _disposable;
        
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _maskRT;
        private const float Spacing = 25;
        private const float OfferSizeY = 70;
        private const float PrefabSize = OfferSizeY + Spacing;
        private readonly Vector3 _offerPrefabHalfSize = new Vector3(0, PrefabSize / 2,0);
        private readonly Vector3 _startPos = Vector2.zero;
        private readonly Vector3 _offsetVec = Vector3.down;

        private int _numVisible;
        private int _numBuffer = 2;

        private List<OfferView> _offers = new List<OfferView>();
        private Dictionary<OfferData, OfferView> _offerViewPairs = new Dictionary<OfferData, OfferView>();
        private int _numItems = 0;


        [Inject]
        private void Construct(DiContainer container)
        {
            _offersHandler = container.Resolve<IOffersHandler>();
            _offersFactory = container.Resolve<IOffersFactory>();
            
            _disposable = new CompositeDisposable();
        }

        private void Start()
        {
            Setup();
        }

        private void Setup()
        {
            _offersHandler.Offers.ObserveRemove().Subscribe((offer) => OfferRemoved(offer)).AddTo(_disposable);

            if (_offersFactory.IsSetuped) CreateOffers(_offersHandler.Offers);
            else _offersFactory.OnSetuped.Subscribe((value) => CreateOffers(_offersHandler.Offers)).AddTo(_disposable);
        }

        private void CreateOffers(ReactiveCollection<OfferData> offers)
        {
            int offersAmount = offers.Count;
            
            _container.sizeDelta = new Vector2(_container.sizeDelta.x, PrefabSize * offersAmount);

            _numVisible = Mathf.CeilToInt(_maskRT.rect.size.y / PrefabSize);
            // numItems = Optimize ? Mathf.Min(Num, numVisible + numBuffer) : Num;
            _numItems = offersAmount;

            for (int i = 0; i < _numItems; i++)
            {
                OfferView offer = _offersFactory.Get(offers[i]);
                
                offer.SetParentAndPosition(_container.transform,i+1,GetPositionByIndex(i));
                
                _offers.Add(offer);
                _offerViewPairs.Add(offers[i], offer);
            }
            
            _container.anchoredPosition = new Vector3(-_container.sizeDelta.x/2,0);
        }
        
        private void OfferRemoved(CollectionRemoveEvent<OfferData> offer)
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

        //OLD IMPLEMENTATION
        
        // private void CreateOffers(ReactiveCollection<OfferData> offers)
        // {
        //     float containerStartPositionX = _container.anchoredPosition3D.x; //КОСТЫЛЬ
        //     
        //     _container.anchoredPosition3D = new Vector3(0, 0, 0);
        //     
        //     _prefabSize = _offerSizeY + _spacing;
        //     int offersAmount = offers.Count;
        //     
        //     _container.sizeDelta = new Vector2(_container.sizeDelta.x, _prefabSize * offersAmount);
        //     float containerHalfSize = _container.rect.size.y * 0.5f;
        //
        //     _numVisible = Mathf.CeilToInt(_maskRT.rect.size.y / _prefabSize);
        //
        //     _offsetVec = Vector3.down;
        //     _startPos = _container.anchoredPosition3D - (_offsetVec * containerHalfSize) + (_offsetVec * ( _offerSizeY * 0.5f));
        //     // numItems = Optimize ? Mathf.Min(Num, numVisible + numBuffer) : Num;
        //     _numItems = offersAmount;
        //     for (int i = 0; i < _numItems; i++)
        //     {
        //         OfferView offer = _offersFactory.Get(offers[i]);
        //         offer.SetParentAndPosition(i+1, _container.transform,_startPos + (_offsetVec * i * _prefabSize));
        //         
        //         _listItemRect.Add(offer);
        //         _itemDict.Add(offer.GetInstanceID(), new int[] { i, i });
        //     }
        //      
        //     _container.anchoredPosition3D += _offsetVec * (containerHalfSize - _maskRT.rect.size.y * 0.5f);
        //
        //     _container.anchoredPosition3D = new Vector3(containerStartPositionX,_container.anchoredPosition3D.y,_container.anchoredPosition3D.z );  //КОСТЫЛЬ
        // }
    }
}