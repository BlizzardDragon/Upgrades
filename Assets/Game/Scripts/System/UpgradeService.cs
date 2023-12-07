public class UpgradeService
{
    private readonly Upgrade[] _upgrades;

    public UpgradeService(Upgrade[] upgrades)
    {
        _upgrades= upgrades;
    }

    public Upgrade[] GetUpgrades() => _upgrades;
}
