using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class MovingAverage : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int InputWindowSize { get; set; }
        public Signal OutputAverageSignal { get; set; }
 
        public override void Run()
        {
            List<float> samples = new List<float>();
            for(int i = 0; i < (InputSignal.Samples.Count - InputWindowSize +1); i++)
            {
                samples.Add(0);
                for(int j = i; j < (InputWindowSize + i); j++)
                {
                    samples[i] += InputSignal.Samples[j];
                }
                samples[i] /= InputWindowSize;
            }
            OutputAverageSignal = new Signal(samples, false);
        }
    }
}
