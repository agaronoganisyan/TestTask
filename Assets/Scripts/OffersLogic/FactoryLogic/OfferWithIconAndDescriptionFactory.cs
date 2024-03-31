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
    public class OfferWithIconAndDescriptionFactory : ObjectFactory<OfferWithIconAndDescriptionView>
    {
        private const string FactoryConfigAddress = "OfferWithIconAndDescriptionFactoryConfig";

        private IAssetsProvider _assetsProvider;
        
        public OfferWithIconAndDescriptionFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<OfferWithIconAndDescriptionView>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup()
        {
            ScriptableObject configPrefab =  await _assetsProvider.Load<ScriptableObject>(FactoryConfigAddress);
            OfferFactoryConfig config = (OfferFactoryConfig)configPrefab;
            
            _pool.Setup(config.Prefab.GetComponent<OfferWithIconAndDescriptionView>(), config.InitialPoolSize);
        }

        public OfferWithIconAndDescriptionView Get(OfferViewModel offerViewModel)
        {
            OfferWithIconAndDescriptionView offer = base.Get();
            offer.Setup(offerViewModel);
            return offer;
        }
    }
}