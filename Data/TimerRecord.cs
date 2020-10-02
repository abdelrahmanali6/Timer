using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using Timer.Model;

namespace Timer.Data
{
    public class TimerRecord : ITimerRecord
    {
        Stopwatch stopwatch = new Stopwatch();
        ConcurrentDictionary<string ,TimerRecord> dictionary = new ConcurrentDictionary<string , TimerRecord>();

        public TimerModel endProcess(string ID)
        {
            TimerModel timer = new TimerModel();
            TimerRecord time ;
            if(!dictionary.TryGetValue(ID,out time))
            {
                timer=null;
                return timer;
            }
           string timeElapsed = time.endTimer();
           timer.ID = ID;
           timer.Time=timeElapsed;
           return timer;
        }

        public string endTimer()
        {
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours,ts.Minutes, ts.Seconds, ts.Milliseconds/10);
            return elapsedTime;
        }

        public TimerModel Reset(string ID)
        {   
            TimerModel timer = new TimerModel();
            TimerRecord time ;
            if(!dictionary.TryGetValue(ID,out time))
            {
                timer=null;
                return timer;
            }
            time.stopwatch.Reset();
            dictionary[ID]=time;
            timer.ID=ID;
            timer.Time="00:00:00.00";
            return timer;
        }

        public TimerModel startProcess()
        {
            TimerRecord timer = new TimerRecord();
            string myUniqueID = string.Format(@"{0}", Guid.NewGuid());
            TimerModel model= new TimerModel();
            model.ID = myUniqueID;
            model.Time="00:00:00.00";
            timer.startTimer();
            dictionary.TryAdd(myUniqueID,timer);
            return model;
        }

        public void startTimer()
        {
             stopwatch.Start();

        }
    }
}