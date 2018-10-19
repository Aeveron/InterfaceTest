namespace Pomodoro
{
    public interface INotifyObject
    {
        void Tick(int minutes, int seconds);
    }
}
