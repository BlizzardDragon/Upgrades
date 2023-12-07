public class LumberControlPresentationModel : IConveyorControlPresentationModel
{
    private readonly ConveyorManager _conveyorManager;

    public LumberControlPresentationModel(ConveyorManager conveyorManager)
    {
        _conveyorManager = conveyorManager;
    }
    

    public void OnIncrease() => _conveyorManager.AddLumber();
    public void OnReduce() => _conveyorManager.RemoveLumber();
}