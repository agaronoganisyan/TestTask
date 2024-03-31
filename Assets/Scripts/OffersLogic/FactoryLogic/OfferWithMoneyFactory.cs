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
    public class OfferWithMoneyFactory : ObjectFactory<OfferWithMoneyView>
    {
        private const string FactoryConfigAddress = "OfferWithMoneyFactoryConfig";

        private IAssetsProvider _assetsProvider;
        
        public OfferWithMoneyFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<OfferWithMoneyView>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup()
        {
            ScriptableObject configPrefab =  await _assetsProvider.Load<ScriptableObject>(FactoryConfigAddress);
            OfferFactoryConfig config = (OfferFactoryConfig)configPrefab;
            
            _pool.Setup(config.Prefab.GetComponent<OfferWithMoneyView>(), config.InitialPoolSize);
        }

        public OfferWithMoneyView Get(OfferViewModel offerViewModel)
        {
            OfferWithMoneyView offer = base.Get();
            offer.Setup(offerViewModel);
            return offer;
        }
    }
}