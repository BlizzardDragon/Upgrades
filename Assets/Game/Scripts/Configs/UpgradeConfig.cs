using Game.Meta;
using UnityEngine;
using VContainer;

namespace Lessons.MetaGame.Upgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        public string Id;
        [Range(2, 99)]
        public int MaxLevel;
        public UpgradePriceTable PriceTable;


        public abstract Upgrade InstantiateUpgrade(IObjectResolver resolver);
        protected virtual void OnValidate() => PriceTable.OnValidate(MaxLevel);
    }
}