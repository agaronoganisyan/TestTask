using AssetManagementLogic;
using Cysharp.Threading.Tasks;
using ObjectFactoryLogic;
using OffersLogic.FactoryLogic.ConfigLogic;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using PoolLogic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OfferWithDoubleIconFactory : ObjectFactory<OfferWithDoubleIconView>
    {
        private const string FactoryConfigAddress = "OfferWithDoubleIconFactoryConfig";

        private IAssetsProvider _assetsProvider;
        
        public OfferWithDoubleIconFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<OfferWithDoubleIconView>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup()
        {
            ScriptableObject configPrefab =  await _assetsProvider.Load<ScriptableObject>(FactoryConfigAddress);
            OfferFactoryConfig config = (OfferFactoryConfig)configPrefab;
            
            _pool.Setup(config.Prefab.GetComponent<OfferWithDoubleIconView>(), config.InitialPoolSize);
        }

        public OfferWithDoubleIconView Get(OfferViewModel offerViewModel)
        {
            OfferWithDoubleIconView offer = base.Get();
            offer.Setup(offerViewModel);
            return offer;
        }
    }
}