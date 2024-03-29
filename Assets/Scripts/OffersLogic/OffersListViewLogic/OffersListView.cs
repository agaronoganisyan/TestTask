using System.Collections.Generic;
using OffersLogic.FactoryLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using UniRx;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using Zenject;

namespace OffersLogic.OffersListViewLogic
{
    public class OffersListView : MonoBehaviour
    {
        private IOffersHandler _offersHandler;
        private IOffersFactory _offersFactory;
        
        private CompositeDisposable _disposable;
        
        private RectTransform _container;
        private RectTransform _maskRT;
        public float _spacing;
        private const float _offerSizeY = 70;
        
        private int _numVisible;
        private int _numBuffer = 2;
        private float _prefabSize;

        private Dictionary<int, int[]> _itemDict = new Dictionary<int, int[]>();
        private List<OfferView> _listItemRect = new List<OfferView>();
        private List<ListItem> _listItems = new List<ListItem>();
        private int _numItems = 0;
        private Vector3 _startPos;
        private Vector3 _offsetVec;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _offersHandler = container.Resolve<IOffersHandler>();
            _offersFactory = container.Resolve<IOffersFactory>();
            
            _disposable = new CompositeDisposable();
        }

        private void Start() //
        {
            Setup();
        }

        private void Setup()
        {
            _offersHandler.Offers.ObserveRemove().Subscribe((offer) => OfferRemoved(offer)).AddTo(_disposable);

            CreateOffers(_offersHandler.Offers);
        }

        private void CreateOffers(ReactiveCollection<OfferData> offers)
        {
            _container.anchoredPosition3D = new Vector3(0, 0, 0);
            
            _prefabSize = _offerSizeY + _spacing;
            int offersAmount = offers.Count;
            
            _container.sizeDelta = new Vector2(_container.sizeDelta.x, _prefabSize * offersAmount);
            float containerHalfSize = _container.rect.size.y * 0.5f;

            _numVisible = Mathf.CeilToInt(_maskRT.rect.size.y / _prefabSize);

            _offsetVec = Vector3.down;
            _startPos = _container.anchoredPosition3D - (_offsetVec * containerHalfSize) + (_offsetVec * ( _offerSizeY * 0.5f));
            // numItems = Optimize ? Mathf.Min(Num, numVisible + numBuffer) : Num;
            // numItems = offersAmount;
            for (int i = 0; i < _numItems; i++)
            {
                OfferView offer = _offersFactory.Get(offers[i]);
                offer.SetParentAndPosition(_container.transform,_startPos + (_offsetVec * i * _prefabSize));
                
                _listItemRect.Add(offer);
                _itemDict.Add(offer.GetInstanceID(), new int[] { i, i });
            }
             
            _container.anchoredPosition3D += _offsetVec * (containerHalfSize - _maskRT.rect.size.y * 0.5f);
        }

        private void OfferRemoved(CollectionRemoveEvent<OfferData> offer)
        {
            //offer.Value;
        }
    }
}