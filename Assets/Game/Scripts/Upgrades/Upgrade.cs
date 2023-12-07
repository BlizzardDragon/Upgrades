using System;
using Lessons.MetaGame.Upgrades;
using Sirenix.OdinInspector;

public abstract class Upgrade
{
    [ShowInInspector, ReadOnly]
    public string Id => _config.Id;

    [ShowInInspector, ReadOnly]
    public int Level => _level;

    [ShowInInspector, ReadOnly]
    public int MaxLevel => _config.MaxLevel;

    [ShowInInspector, ReadOnly]
    public bool IsMaxLevel => _level >= _config.MaxLevel;

    [ShowInInspector, ReadOnly]
    public int NextPrice => _config.PriceTable.GetPrice(_level + 1);

    private readonly UpgradeConfig _config;
    private int _level = 1;

    protected Upgrade(UpgradeConfig config)
    {
        _config = config;
    }


    [Button]
    public void LevelUp()
    {
        if (IsMaxLevel)
        {
            throw new Exception("Can't upgrade max level!");
        }

        _level++;
        OnLevelUp(_level);
    }

    public abstract void OnLevelUp(int level);
    public abstract void Initialize();
}
