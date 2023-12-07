using Elementary;

namespace Game.Gameplay
{
    public class Component_WorkTimer : IComponent_WorkTimer
    {
        public float Duration => _timer.Duration;
        private Timer _timer = new();

        public Component_WorkTimer(Timer timer)
        {
            _timer = timer;
        }

        public void SetDuration(float duration)
        {
            _timer.Duration = duration;
        }
    }
}