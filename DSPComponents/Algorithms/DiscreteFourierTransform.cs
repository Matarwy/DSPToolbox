using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }
        struct Complex
        {
            public float real, imagin;
        }
        public override void Run()
        {
            
            List<float> Frequencies = new List<float>();
            List<float> FrequenciesAmplitudes = new List<float>();
            List<float> FrequenciesPhaseShifts = new List<float>();
            float ePow;
            float N = InputTimeDomainSignal.Samples.Count;

            for (int i = 0; i < N; i++)
            {
                Complex complex = new Complex();
                complex.real = 0;
                complex.imagin = 0;
                for(int j = 0; j < N; j++)
                {
                    ePow = (2 * i * j * ((float)Math.PI)) / N;
                    complex.real += InputTimeDomainSignal.Samples[j] * (float)Math.Cos(ePow);
                    complex.imagin += -InputTimeDomainSignal.Samples[j] * (float)Math.Sin(ePow);
                }

                float amp = (float)Math.Sqrt((float)Math.Pow(complex.real,2)+(float)Math.Pow(complex.imagin, 2));
                float phase = (float)Math.Atan2(complex.imagin,complex.real);

                FrequenciesAmplitudes.Add(amp);
                FrequenciesPhaseShifts.Add(phase);
            }
            OutputFreqDomainSignal = new Signal(false, Frequencies, FrequenciesAmplitudes, FrequenciesPhaseShifts);
        }
    }
}
