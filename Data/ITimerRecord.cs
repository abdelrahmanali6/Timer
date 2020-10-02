using Timer.Model;

namespace Timer.Data
{
    public interface ITimerRecord
    {
        TimerModel startProcess();
        void startTimer();
        string endTimer();

        TimerModel endProcess(string ID);

        TimerModel Reset(string ID);
    }
}