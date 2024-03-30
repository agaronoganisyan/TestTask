using AssetManagementLogic;
using Cysharp.Threading.Tasks;
using ObjectFactoryLogic;
using OffersLogic.FactoryLogic.ConfigLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using PoolLogic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace OffersLogic.FactoryLogic
{
    public class OffersWithDescriptionFactory : ObjectFactory<OfferWithDescriptionView>
    {
        private const string FactoryConfigAddress = "OfferWithDescriptionFactoryConfig";

        private IAssetsProvider _assetsProvider;
        
        public OffersWithDescriptionFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<OfferWithDescriptionView>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup()
        {
            ScriptableObject configPrefab =  await _assetsProvider.Load<ScriptableObject>(FactoryConfigAddress);
            OfferFactoryConfig config = (OfferFactoryConfig)configPrefab;//.GetComponent<OfferFactoryConfig>();
            
            _pool.Setup(config.Prefab.GetComponent<OfferWithDescriptionView>(), config.InitialPoolSize);
        }

        public OfferWithDescriptionView Get(OfferData data)
        {
            OfferWithDescriptionView offer = base.Get();
            offer.Setup(data);
            return offer;
        }
    }
}