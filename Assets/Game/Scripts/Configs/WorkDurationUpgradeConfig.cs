using FrameworkUnity.OOP.VContainer.Extensions;
using Lessons.MetaGame.Upgrades;
using UnityEngine;
using VContainer;

[CreateAssetMenu(fileName = "WorkDurationUpgradeConfig", menuName = "UpgradeConfigs/WorkDurationUpgradeConfig")]
public class WorkDurationUpgradeConfig : UpgradeConfig
{
    public WorkDurationUpgradeTable Table;


    protected override void OnValidate()
    {
        base.OnValidate();
        Table.OnValidate(MaxLevel);
    }

    public override Upgrade InstantiateUpgrade(IObjectResolver resolver)
    {
        return resolver.CreateInstance<WorkDurationUpgrade>();
    }
}