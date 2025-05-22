using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.DataAccess.Scripts
{
    public class CreateSlots
    {
        public int Y;
        public int M;
        public int D;
        public int StartTime;
        public int StopTime;
        public int Chunk;
        public int Days;
        public CreateSlots(int y, int m, int d, int startTime, int stopTime, int chunk, int days) 
        {
            this.Y = y;
            this.M = m;
            this.D = d;
            this.StartTime = startTime;
            this.StopTime = stopTime;
            this.Chunk = chunk;
            this.Days = days; 
        }    


        public List<List<string>> Run() 
        {
            List<string> result = SplitedDay(this.Y, this.M, this.D, this.StartTime, this.StopTime, this.Chunk, this.Days);
            List<List<string>> result1 = CollectSlots(result);
            return result1;
            }


        // вернёт рабочие дни
        public static List<DateTime> AddBusinessDays(DateTime start, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            var businessDays = new List<DateTime>(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    start = start.AddDays(sign);
                }
                while (start.DayOfWeek == DayOfWeek.Saturday ||
                    start.DayOfWeek == DayOfWeek.Sunday);
                businessDays.Add(start);
            }
            return businessDays;
        }


        // расставит метки каждые 'chunk' минут
        public static List<string> SplitedDay(int startYear, int startMonth, int startDay,
                                                //int stopYear, int stopMonth, int stopDay,
                                                int workStartTime, int workStopTime,
                                                int chunkTime, int days)
        {
            var startWorkingDay = new DateTime(startYear, startMonth, startDay);
            //var stopWorkingDay = new DateTime(stopYear, stopMonth, stopDay);
            List<DateTime> businessDays = AddBusinessDays(startWorkingDay, days);
            List<string> result = new List<string>();
            foreach (var day in businessDays)
            {
                var startTS = new DateTime(day.Year, day.Month, day.Day, workStartTime, 0, 0);
                var endTS = new DateTime(day.Year, day.Month, day.Day, workStopTime, 0, 0);
                long ticksPerSecond = 10000000;
                long ticksPerMinute = ticksPerSecond * 60;
                long ticksPer20Min = ticksPerMinute * chunkTime;
                long startTSInTicks = startTS.Ticks;
                long endTsInTicks = endTS.Ticks;
                for (long i = startTSInTicks; i <= endTsInTicks; i += ticksPer20Min)
                {
                    DateTime res = new DateTime(i);
                    result.Add(res.ToString());
                }
            }
            return result;
        }


        // соберёт отдельные метки в слоты вида [s1,s2], [s2,s3], [s3,s4]
        public static List<List<string>> CollectSlots(List<string> allSplits)
        {
            int counter = 0;    // сквозной счётчкик
            int step = 0;       // >=2
            List<List<string>> result = new List<List<string>>();
            List<string> slot = new List<string>(2);
            while (allSplits.Count() > (counter - step))
            {
                if (slot.Count() == 0)
                {
                    slot.Insert(0, allSplits[counter - step]);
                    counter++;
                }
                else if (slot.Count() == 1)
                {
                    slot.Insert(1, allSplits[counter - step]);
                    result.Add(slot);
                    slot = new List<string>(2);
                    counter++;
                    step++;
                }
            }
            return result;
        }
        }
}

