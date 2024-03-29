using AssetManagementLogic;
using OffersLogic.FactoryLogic;
using PurchaseLogic.PurchaseHandlerLogic;
using PurchaseLogic.PurchaseProcessLogic;
using PurchaseLogic.PurchaseSystemLogic;
using UnityEngine;
using Zenject;

namespace InfrastructureLogic
{
    public class GameBootstrapper : MonoBehaviour
    {
        private DiContainer _container;
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        
        private async void Start()
        {
            _container.Resolve<IAssetsProvider>().Initialize();
            await _container.Resolve<IOffersFactory>().Setup();
            _container.Resolve<IPurchaseSystem>().Setup();
            _container.Resolve<IPurchaseHandler>().Setup();
            _container.Resolve<IPurchaseProcess>().Setup();
        }
    }
}