using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class SinCos: Algorithm
    {
        public string type { get; set; }
        public float A { get; set; }
        public float PhaseShift { get; set; }
        public float AnalogFrequency { get; set; }
        public float SamplingFrequency { get; set; }
        public List<float> samples { get; set; }
        public override void Run()
        {
            float Sample;
            float f = AnalogFrequency / SamplingFrequency;
            samples = new List<float>();
            if (SamplingFrequency >= (2 * AnalogFrequency))   // Fs >= 2F "true"
            {
                if (String.Equals(type, "cos"))
                {
                    for (int i = 0; i < SamplingFrequency; i++)
                    {
                        Sample = A * (float)Math.Cos((2 * Math.PI * f * i) + PhaseShift);
                        samples.Add(Sample);  //A cos(2 pi f) * 
                        Console.WriteLine(Sample);
                    }
                }
                else if (String.Equals(type, "sin"))
                {
                    for (int i = 0; i < SamplingFrequency; i++)
                    {
                        Sample = A * (float)Math.Sin((2 * Math.PI * f *i) + PhaseShift);
                        samples.Add(Sample);
                        Console.WriteLine(Sample);
                    }
                }
            }
        }
    }
}
