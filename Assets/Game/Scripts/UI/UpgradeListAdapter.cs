using VContainer.Unity;

public class UpgradeListAdapter : IInitializable
{
    private UpgradeService _upgradeService;
    private UpgradeView[] _upgradeViews;

    public UpgradeListAdapter(UpgradeService upgradeService, UpgradeView[] upgradeViews)
    {
        _upgradeService = upgradeService;
        _upgradeViews = upgradeViews;
    }


    public void Initialize()
    {
        Upgrade[] upgrades = _upgradeService.GetUpgrades();

        for (int i = 0; i < upgrades.Length; i++)
        {
            var presenter = new UpgradePresenter(upgrades[i], _upgradeViews[i]);
            presenter.Init();
        }
    }
}