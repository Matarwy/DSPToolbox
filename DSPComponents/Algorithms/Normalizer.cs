using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {
            List<float> OutputSamples = new List<float>();
            float MaxSampleValue = InputSignal.Samples[0];
            float MinSampleValue = InputSignal.Samples[0];

            for(int i=0; i< InputSignal.Samples.Count; i++)
            {
                if(InputSignal.Samples[i] > MaxSampleValue)
                    MaxSampleValue = InputSignal.Samples[i];

                if(InputSignal.Samples[i] < MinSampleValue)
                    MinSampleValue = InputSignal.Samples[i];
            }

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                float Sample = (InputMaxRange - InputMinRange)*((InputSignal.Samples[i] - MinSampleValue) / (MaxSampleValue - MinSampleValue)) + InputMinRange;
                OutputSamples.Add(Sample);
            }

            OutputNormalizedSignal = new Signal(OutputSamples, false);
        }
    }
}
