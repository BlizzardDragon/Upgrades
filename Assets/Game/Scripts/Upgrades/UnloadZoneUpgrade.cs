using Entities;
using Game.Gameplay;
using VContainer;

public class UnloadZoneUpgrade : Upgrade
{
    private UnloadZoneUpgradeConfig _config;
    private IEntity _entity;

    public UnloadZoneUpgrade(UnloadZoneUpgradeConfig config) : base(config) => _config = config;


    [Inject]
    public void Construct(IEntity entity) => _entity = entity;

    public override void Initialize() => SetMaxSize(Level);
    public override void OnLevelUp(int level) => SetMaxSize(Level);

    private void SetMaxSize(int level)
    {
        int maxSize = _config.Table.GetMaxSize(level);
        _entity.Get<IComponent_UnloadZone>().SetMaxValue(maxSize);
    }
}
