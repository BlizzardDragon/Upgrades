using Game.Gameplay;
using Game.Gameplay.Conveyors;

public class ConveyorManager
{
    private readonly ConveyorEntity _entity;

    public ConveyorManager(ConveyorEntity entity)
    {
        _entity = entity;
    }

    public void AddLumber()
    {
        var unloadZone = _entity.Get<Component_UnloadZone>();
        unloadZone.SetupAmount(unloadZone.CurrentAmount + 1);
    }

    public void RemoveLumber()
    {
        var unloadZone = _entity.Get<Component_UnloadZone>();
        unloadZone.SetupAmount(unloadZone.CurrentAmount - 1);
    }

    public void AddLog()
    {
        var unloadZone = _entity.Get<Component_LoadZone>();
        unloadZone.SetupAmount(unloadZone.CurrentAmount + 1);
    }

    public void RemoveLog()
    {
        var unloadZone = _entity.Get<Component_LoadZone>();
        unloadZone.SetupAmount(unloadZone.CurrentAmount - 1);
    }
}
