using System;
using Game.GameEngine.GameResources;

namespace Game.Gameplay
{
    public interface IComponent_LoadZone
    {
        event Action<int> OnAmountChanged;
        
        int MaxAmount { get; }
        
        int CurrentAmount { get; }
        
        int AvailableAmount { get; }
        
        bool IsFull { get; }
        
        ResourceType ResourceType { get; }
        
        void SetupAmount(int currentAmount);
        
        void PutAmount(int range);
        void SetMaxValue(int value);
    }
}