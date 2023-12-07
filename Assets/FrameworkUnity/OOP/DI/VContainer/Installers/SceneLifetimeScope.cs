using Entities;
using Game.Gameplay.Conveyors;
using Lessons.MetaGame.Upgrades;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FrameworkUnity.OOP.VContainer.Installers
{
    public class SceneLifetimeScope : BaseGameInstallerVContainer
    {
        [Space]
        [SerializeField] private ConveyorControlView _logControl;
        [SerializeField] private ConveyorControlView _lumberControl;
        
        [SerializeField] private UpgradeView[] _upgradeViews;
        [SerializeField] private UpgradeConfig[] _configs;


        protected override void ConfigureSystems(IContainerBuilder builder)
        {
            ConfigureInstallers(builder);
            ConfigureGameSystems(builder);
            ConfigureUpgrades(builder);
            ConfigureConfigs(builder);
            ConfigureUI(builder);
        }

        private void ConfigureInstallers(IContainerBuilder builder)
        {
            builder.Register<UpgradeInstaller>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void ConfigureGameSystems(IContainerBuilder builder)
        {
            builder.Register<UpgradeService>(Lifetime.Singleton).AsSelf();
            builder.Register<ConveyorManager>(Lifetime.Singleton).AsSelf();
            builder.RegisterComponentInHierarchy<ConveyorEntity>().As<IEntity>().AsSelf();
        }

        private void ConfigureUpgrades(IContainerBuilder builder)
        {
            builder.Register(CreateUpgrades, Lifetime.Singleton);
        }

        private void ConfigureConfigs(IContainerBuilder builder)
        {
            foreach (var config in _configs)
            {
                builder.RegisterInstance(config).AsSelf();
            }
        }

        private void ConfigureUI(IContainerBuilder builder)
        {
            builder.Register(GetUpgradeViews, Lifetime.Singleton);
            builder.Register<LogControlPresentationModel>(Lifetime.Singleton);
            builder.Register<LumberControlPresentationModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<UpgradeListAdapter>();
        }

        private Upgrade[] CreateUpgrades(IObjectResolver resolver)
        {
            Upgrade[] upgrades = new Upgrade[_configs.Length];

            for (int i = 0; i < _configs.Length; i++)
            {
                upgrades[i] = _configs[i].InstantiateUpgrade(resolver);
            }

            return upgrades;
        }

        private UpgradeView[] GetUpgradeViews(IObjectResolver _) => _upgradeViews;

        protected override void Awake()
        {
            base.Awake();

            _logControl.Setup(Container.Resolve<LogControlPresentationModel>());
            _lumberControl.Setup(Container.Resolve<LumberControlPresentationModel>());
        }
    }
}
