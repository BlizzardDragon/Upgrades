using VContainer.Unity;

public class UpgradeInstaller : IPostStartable
{
    private readonly UpgradeService _upgradeService;

    public UpgradeInstaller(UpgradeService upgradeService)
    {
        _upgradeService = upgradeService;
    }


    public void PostStart()
    {
        foreach (var upgrade in _upgradeService.GetUpgrades())
        {
            upgrade.Initialize();
        }
    }
}