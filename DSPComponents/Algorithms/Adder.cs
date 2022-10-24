using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Adder : Algorithm
    {
        public List<Signal> InputSignals { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> OutputSamples = new List<float>();
            int OutputSignalSize = 0;

            for (int i = 0; i < InputSignals.Count; i++)
            {
                if(InputSignals[i].Samples.Count > OutputSignalSize)
                {
                    OutputSignalSize = InputSignals[i].Samples.Count;
                }
            }

            for (int i = 0; i < OutputSignalSize; i++)
            {
                float Sample = 0;
                for (int j = 0; j < InputSignals.Count; j++)
                {
                    if (InputSignals[j].Samples.Count > i)
                        Sample += InputSignals[j].Samples[i];
                    else
                        Sample += 0;
                }
                OutputSamples.Add(Sample);
            }

            OutputSignal = new Signal(OutputSamples, false);
        }
    }
}