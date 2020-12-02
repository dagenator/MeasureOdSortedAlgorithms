using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MeasureOdSortedAlgorithms
{
    class TimeMeasure
    {
        public double MesureOfWork(Func<string[], string[]> Sort, double count, string[] input )
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i< count; i++)
            {
                Sort(input);
            }

            double res = stopWatch.ElapsedMilliseconds / count;
            return res;
        }

    }
}
