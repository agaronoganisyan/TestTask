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
            Container.Bind<CurrencyModel>().FromInstance(GetComponent<CurrencyModel>()).AsSingle();
            Container.Bind<OffersModel>().FromInstance(GetComponent<OffersModel>()).AsSingle();
            
            Container.Bind<IStateMachine<PurchaseProcessType>>().To<SimpleStateMachine<PurchaseProcessType>>().FromNew().AsSingle();
            Container.Bind<NotEnoughCurrencyState>().FromNew().AsSingle();
            Container.Bind<PurchaseConfirmState>().FromNew().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().FromNew().AsSingle();
            
            Container.Bind<ObjectPool<OfferView>>().FromNew().AsTransient();
            
            // Container.Bind<ObjectPool<OfferWithDescriptionView>>().FromNew().AsSingle();
            // Container.Bind<ObjectPool<OfferWithDoubleDescriptionView>>().FromNew().AsSingle();
            // Container.Bind<ObjectPool<OfferWithDoubleIconView>>().FromNew().AsSingle();
            // Container.Bind<ObjectPool<OfferWithIconAndDescriptionView>>().FromNew().AsSingle();
            // Container.Bind<ObjectPool<OfferWithIconView>>().FromNew().AsSingle();
            // Container.Bind<ObjectPool<OfferWithMoneyView>>().FromNew().AsSingle();
            
            Container.Bind<OffersWithDescriptionFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithDoubleDescriptionFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithDoubleIconFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithIconAndDescriptionFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithIconFactory>().FromNew().AsSingle();
            Container.Bind<OfferWithMoneyFactory>().FromNew().AsSingle();

            Container.Bind<OfferWithDescriptionViewModel>().FromNew().AsTransient();
            Container.Bind<OfferWithDoubleDescriptionViewModel>().FromNew().AsTransient();
            Container.Bind<OfferWithDoubleIconViewModel>().FromNew().AsTransient();
            Container.Bind<OfferWithIconAndDescriptionViewModel>().FromNew().AsTransient();
            Container.Bind<OfferWithIconViewModel>().FromNew().AsTransient();
            Container.Bind<OfferWithMoneyViewModel>().FromNew().AsTransient();
            
            Container.Bind<IOfferViewModelFactory>().To<OfferViewModelFactory>().FromNew().AsSingle();
            Container.Bind<IOffersViewFactory>().To<OffersViewFactory>().FromNew().AsSingle();
            Container.Bind<IOffersListViewModel>().To<OffersListViewModel>().FromNew().AsSingle();
            Container.Bind<IPurchaseProcess>().To<PurchaseProcess>().FromNew().AsSingle();
            Container.Bind<ICurrencyViewModel>().To<CurrencyViewModel>().FromNew().AsSingle();
            Container.Bind<IPurchaseSystem>().To<PurchaseSystem>().FromNew().AsSingle();
            Container.Bind<IPurchaseHandler>().To<PurchaseHandler>().FromNew().AsSingle();
        }
    }
}
