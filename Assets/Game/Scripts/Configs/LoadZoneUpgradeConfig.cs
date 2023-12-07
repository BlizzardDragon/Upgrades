using FrameworkUnity.OOP.VContainer.Extensions;
using Lessons.MetaGame.Upgrades;
using UnityEngine;
using VContainer;

[CreateAssetMenu(fileName = "LoadZoneUpgradeConfig", menuName = "UpgradeConfigs/LoadZoneUpgradeConfig")]
public class LoadZoneUpgradeConfig : UpgradeConfig
{
    public LoadZoneUpgradeTable Table;


    protected override void OnValidate()
    {
        base.OnValidate();
        Table.OnValidate(MaxLevel);
    }

    public override Upgrade InstantiateUpgrade(IObjectResolver resolver)
    {
        return resolver.CreateInstance<LoadZoneUpgrade>();
    }
}