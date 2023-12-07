namespace Game.Gameplay
{
    public interface IComponent_WorkTimer
    {
        float Duration { get; }
        void SetDuration(float duration);
    }
}