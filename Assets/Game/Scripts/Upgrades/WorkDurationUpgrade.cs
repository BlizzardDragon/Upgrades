using Entities;
using Game.Gameplay;
using VContainer;
using VContainer.Unity;

public class WorkDurationUpgrade : Upgrade, IInitializable
{
    private WorkDurationUpgradeConfig _config;
    private IEntity _entity;

    public WorkDurationUpgrade(WorkDurationUpgradeConfig config) : base(config) => _config = config;


    [Inject]
    public void Construct(IEntity entity) => _entity = entity;

    public override void Initialize() => SetDuration(Level);
    public override void OnLevelUp(int level) => SetDuration(Level);

    private void SetDuration(int level)
    {
        float duration = _config.Table.GetDuration(level);
        _entity.Get<IComponent_WorkTimer>().SetDuration(duration);
    }
}
