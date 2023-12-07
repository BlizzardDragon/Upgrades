using Entities;
using Game.Gameplay;
using VContainer;
using VContainer.Unity;

public class LoadZoneUpgrade : Upgrade, IInitializable
{
    private LoadZoneUpgradeConfig _config;
    private IEntity _entity;

    public LoadZoneUpgrade(LoadZoneUpgradeConfig config) : base(config) => _config = config;


    [Inject]
    public void Construct(IEntity entity) => _entity = entity;

    public override void Initialize() => SetMaxSize(Level);
    public override void OnLevelUp(int level) => SetMaxSize(Level);

    private void SetMaxSize(int level)
    {
        int maxSize = _config.Table.GetMaxSize(level);
        _entity.Get<IComponent_LoadZone>().SetMaxValue(maxSize);
    }
}
