public class LogControlPresentationModel : IConveyorControlPresentationModel
{
    private readonly ConveyorManager _conveyorManager;

    public LogControlPresentationModel(ConveyorManager conveyorManager)
    {
        _conveyorManager = conveyorManager;
    }
    

    public void OnIncrease() => _conveyorManager.AddLog();
    public void OnReduce() => _conveyorManager.RemoveLog();
}