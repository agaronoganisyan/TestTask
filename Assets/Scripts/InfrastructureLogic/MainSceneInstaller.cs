using CurrencyLogic;
using InfoCanvasLogic.NotEnoughCurrencyLogic;
using InfoCanvasLogic.PurchaseConfirmLogic;
using PurchaseLogic.PurchaseHandlerLogic;
using PurchaseLogic.PurchaseSystemLogic;
using Zenject;

namespace InfrastructureLogic
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPurchaseConfirmSystem>().To<PurchaseConfirmSystem>().FromNew().AsSingle();
            Container.Bind<INotEnoughCurrencySystem>().To<NotEnoughCurrencySystem>().FromNew().AsSingle();
            Container.Bind<ICurrencyHandler>().To<CurrencyHandler>().FromNew().AsSingle();
            Container.Bind<IPurchaseSystem>().To<PurchaseSystem>().FromNew().AsSingle();
            Container.Bind<IPurchaseHandler>().To<PurchaseHandler>().FromNew().AsSingle();
        }
    }
}
