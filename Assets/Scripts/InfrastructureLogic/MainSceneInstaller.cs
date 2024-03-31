using AssetManagementLogic;
using CurrencyLogic;
using InfrastructureLogic.StateMachineLogic;
using InfrastructureLogic.StateMachineLogic.Simple;
using OffersLogic;
using OffersLogic.FactoryLogic;
using OffersLogic.OfferHandlerLogic;
using OffersLogic.OfferHandlerLogic.FactoryLogic;
using OffersLogic.OfferHandlerLogic.OffersListHandlerLogic;
using OffersLogic.OffersDataLogic;
using OffersLogic.OffersViewLogic;
using PoolLogic;
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
            Container.Bind<CurrencyData>().FromInstance(GetComponent<CurrencyData>()).AsSingle();
            Container.Bind<OffersData>().FromInstance(GetComponent<OffersData>()).AsSingle();
            
            Container.Bind<IStateMachine<PurchaseProcessType>>().To<SimpleStateMachine<PurchaseProcessType>>().FromNew().AsSingle();
            Container.Bind<NotEnoughCurrencyState>().FromNew().AsSingle();
            Container.Bind<PurchaseConfirmState>().FromNew().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().FromNew().AsSingle();
            
            Container.Bind<ObjectPool<OfferWithDescriptionView>>().FromNew().AsSingle();
            Container.Bind<ObjectPool<OfferWithDoubleDescriptionView>>().FromNew().AsSingle();
            Container.Bind<ObjectPool<OfferWithDoubleIconView>>().FromNew().AsSingle();
            Container.Bind<ObjectPool<OfferWithIconAndDescriptionView>>().FromNew().AsSingle();
            Container.Bind<ObjectPool<OfferWithIconView>>().FromNew().AsSingle();
            Container.Bind<ObjectPool<OfferWithMoneyView>>().FromNew().AsSingle();
            
            Container.Bind<OffersWithDescriptionFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithDoubleDescriptionFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithDoubleIconFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithIconAndDescriptionFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithIconFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithMoneyFactory>().FromNew().AsSingle();

            Container.Bind<OfferWithDescriptionHandler>().FromNew().AsTransient();
            Container.Bind<OfferWithDoubleDescriptionHandler>().FromNew().AsTransient();
            Container.Bind<OfferWithDoubleIconHandler>().FromNew().AsTransient();
            Container.Bind<OfferWithIconAndDescriptionHandler>().FromNew().AsTransient();
            Container.Bind<OfferWithIconHandler>().FromNew().AsTransient();
            Container.Bind<OfferWithMoneyHandler>().FromNew().AsTransient();
            
            Container.Bind<IOfferHandlerFactory>().To<OfferHandlerFactory>().FromNew().AsSingle();
            Container.Bind<IOffersViewFactory>().To<OffersViewFactory>().FromNew().AsSingle();
            Container.Bind<IOffersListHandler>().To<OffersListHandler>().FromNew().AsSingle();
            Container.Bind<IPurchaseProcess>().To<PurchaseProcess>().FromNew().AsSingle();
            Container.Bind<ICurrencyHandler>().To<CurrencyHandler>().FromNew().AsSingle();
            Container.Bind<IPurchaseSystem>().To<PurchaseSystem>().FromNew().AsSingle();
            Container.Bind<IPurchaseHandler>().To<PurchaseHandler>().FromNew().AsSingle();
        }
    }
}
