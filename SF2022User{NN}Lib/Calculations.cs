using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User_NN_Lib
{
    public static class Calculations
    {
        public static string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int? consultationTime)
        {
            int index = 0;
            TimeSpan[] durationOfWork = new TimeSpan[startTimes.Length];
            foreach(var item in startTimes)
            {
                if(beginWorkingTime <= item && endWorkingTime >= item)
                {
                    //Console.WriteLine(item + " - " + new TimeSpan(item.Hours, item.Minutes + durations[index], item.Seconds));
                    durationOfWork[index] = new TimeSpan(item.Hours, item.Minutes + durations[index], item.Seconds);
                    index++;
                }
                else
                {
                    return null;
                }
                
            }
            index = 0;
            foreach(var item in durationOfWork)
            {
                //if(startTimes)
            }
            return null;
        }
    }
}
