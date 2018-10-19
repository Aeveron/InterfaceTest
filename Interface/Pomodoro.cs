using System.Timers;
using Microsoft.Win32;
using Timer = System.Threading.Timer;

namespace Interface
{
    public class Pomodoro
    {
        private int _timeLeftInSeconds;
        private readonly int _startTimeInMinutes;
        private readonly Timer _timer = new Timer(1000);
        private readonly INotifyObject _notifyObject;

        public Pomodoro(INotifyObject notifyObject, int startTimeInMinutes)
        {
            _timer.Elapsed += TimerElapsed;
            _notifyObject = notifyObject;
            _startTimeInMinutes = startTimeInMinutes;
            Reset();
        }

        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timeLeftInSeconds--;
            var minutes = _timeLeftInSeconds / 60;
            var seconds = _timeLeftInSeconds - minutes * 60;
            _notifyObject.Tick(minutes, seconds);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public void Reset()
        {
            _timeLeftInSeconds = 60 * _startTimeInMinutes;
        }
    }
}
