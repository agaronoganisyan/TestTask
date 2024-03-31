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
    public class OfferWithDoubleDescriptionFactory : ObjectFactory<OfferWithDoubleDescriptionView>
    {
        private const string FactoryConfigAddress = "OfferWithDoubleDescriptionFactoryConfig";

        private IAssetsProvider _assetsProvider;
        
        public OfferWithDoubleDescriptionFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<OfferWithDoubleDescriptionView>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup()
        {
            ScriptableObject configPrefab =  await _assetsProvider.Load<ScriptableObject>(FactoryConfigAddress);
            OfferFactoryConfig config = (OfferFactoryConfig)configPrefab;
            
            _pool.Setup(config.Prefab.GetComponent<OfferWithDoubleDescriptionView>(), config.InitialPoolSize);
        }

        public OfferWithDoubleDescriptionView Get(OfferViewModel offerViewModel)
        {
            OfferWithDoubleDescriptionView offer = base.Get();
            offer.Setup(offerViewModel);
            return offer;
        }
    }
}