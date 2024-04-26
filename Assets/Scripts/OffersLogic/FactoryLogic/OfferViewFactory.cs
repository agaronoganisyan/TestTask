using AssetManagementLogic;
using Cysharp.Threading.Tasks;
using ObjectFactoryLogic;
using OffersLogic.FactoryLogic.ConfigLogic;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersViewLogic;
using PoolLogic;
using UnityEngine;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public abstract class OfferViewFactory<T> : ObjectFactory<T> where T : MonoBehaviour, PoolLogic.IPoolable<T>
    {
        private IAssetsProvider _assetsProvider;
        
        public OfferViewFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<T>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup()
        {
            ScriptableObject configPrefab =  await _assetsProvider.Load<ScriptableObject>(FactoryConfigAddress());
            OfferFactoryConfig config = (OfferFactoryConfig)configPrefab;
            
            _pool.Setup(config.Prefab.GetComponent<T>(), config.InitialPoolSize);
        }

        public OfferView Get(OfferViewModel offerViewModel)
        {
            OfferView offer = base.Get() as OfferView;
            offer.Setup(offerViewModel);
            return offer;
        }

        protected abstract string FactoryConfigAddress();
    }
}