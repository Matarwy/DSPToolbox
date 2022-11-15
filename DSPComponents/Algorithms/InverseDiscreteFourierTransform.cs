using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }
        struct Complex
        {
            public float real, imagin;
        }
        public override void Run()
        {
            List<float> samples = new List<float>();
            float sample;
            float N = InputFreqDomainSignal.Frequencies.Count;
            float ePow;
            for (int i = 0; i < N; i++)
            {
                Complex complex = new Complex();
                
                sample = 0;

                for (int j = 0; j < N; j++)
                {
                    complex.real = InputFreqDomainSignal.FrequenciesAmplitudes[j] * (float)Math.Cos(InputFreqDomainSignal.FrequenciesPhaseShifts[j]);
                    complex.imagin = InputFreqDomainSignal.FrequenciesAmplitudes[j] * (float)Math.Sin(InputFreqDomainSignal.FrequenciesPhaseShifts[j]);
                    ePow = (2 * i * j * (float)(Math.PI)) / N;
                    sample += (complex.real * (float)Math.Cos(ePow)) - (complex.imagin * (float)Math.Sin(ePow));
                }
                sample /= N;
                Console.WriteLine(sample);
                samples.Add(sample);
            }
            OutputTimeDomainSignal = new Signal(samples, false);
        }
    }
}
