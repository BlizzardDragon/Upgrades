using FrameworkUnity.OOP.VContainer.Extensions;
using Lessons.MetaGame.Upgrades;
using UnityEngine;
using VContainer;

[CreateAssetMenu(fileName = "UnloadZoneUpgradeConfig", menuName = "UpgradeConfigs/UnloadZoneUpgradeConfig")]
public class UnloadZoneUpgradeConfig : UpgradeConfig
{
    public UnloadZoneUpgradeTable Table;


    protected override void OnValidate()
    {
        base.OnValidate();
        Table.OnValidate(MaxLevel);
    }

    public override Upgrade InstantiateUpgrade(IObjectResolver resolver)
    {
        return resolver.CreateInstance<UnloadZoneUpgrade>();
    }
}