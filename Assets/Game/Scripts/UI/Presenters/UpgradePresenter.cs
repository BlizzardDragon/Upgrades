using System;

public class UpgradePresenter : IDisposable
{
    private Upgrade _upgrade;
    private UpgradeView _upgradeView;

    private readonly string _max = "max";
    private readonly string _lvl = "lvl";

    public UpgradePresenter(Upgrade upgrade, UpgradeView upgradeView)
    {
        _upgrade = upgrade;
        _upgradeView = upgradeView;
    }


    public void Init()
    {
        UpdateText();
        _upgradeView.Button.onClick.AddListener(TryLevelUp);
    }

    public void Dispose() => _upgradeView.Button.onClick.RemoveListener(TryLevelUp);

    private void TryLevelUp()
    {
        if (!_upgrade.IsMaxLevel)
        {
            _upgrade.LevelUp();
            UpdateText();
        }
    }

    private void UpdateText()
    {
        string level = _upgrade.IsMaxLevel ? _max : _upgrade.Level.ToString();
        var text = $"{_upgrade.Id}: {level} {_lvl}";
        _upgradeView.SetText(text);
    }
}