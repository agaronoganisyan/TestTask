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
    public class OfferWithIconFactory : ObjectFactory<OfferWithIconView>
    {
        private const string FactoryConfigAddress = "OfferWithIconFactoryConfig";

        private IAssetsProvider _assetsProvider;
        
        public OfferWithIconFactory(DiContainer container)
        {
            _pool = container.Resolve<ObjectPool<OfferWithIconView>>();
            _assetsProvider = container.Resolve<IAssetsProvider>();
        }
        
        public override async UniTask Setup()
        {
            ScriptableObject configPrefab =  await _assetsProvider.Load<ScriptableObject>(FactoryConfigAddress);
            OfferFactoryConfig config = (OfferFactoryConfig)configPrefab;
            
            _pool.Setup(config.Prefab.GetComponent<OfferWithIconView>(), config.InitialPoolSize);
        }

        public OfferWithIconView Get(OfferViewModel offerViewModel)
        {
            OfferWithIconView offer = base.Get();
            offer.Setup(offerViewModel);
            return offer;
        }
    }
}