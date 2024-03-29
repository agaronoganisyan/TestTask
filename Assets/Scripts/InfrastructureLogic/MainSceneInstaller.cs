using CurrencyLogic;
using InfoCanvasLogic.NotEnoughCurrencyLogic;
using InfoCanvasLogic.PurchaseConfirmLogic;
using PurchaseLogic.PurchaseHandlerLogic;
using PurchaseLogic.PurchaseProcessLogic;
using PurchaseLogic.PurchaseSystemLogic;
using Zenject;

namespace InfrastructureLogic
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPurchaseProcess>().To<PurchaseProcess>().FromNew().AsSingle();
            Container.Bind<ICurrencyHandler>().To<CurrencyHandler>().FromNew().AsSingle();
            Container.Bind<IPurchaseSystem>().To<PurchaseSystem>().FromNew().AsSingle();
            Container.Bind<IPurchaseHandler>().To<PurchaseHandler>().FromNew().AsSingle();
        }
    }
}
