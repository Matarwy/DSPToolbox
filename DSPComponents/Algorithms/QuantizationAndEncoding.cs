using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class QuantizationAndEncoding : Algorithm
    {
        // You will have only one of (InputLevel or InputNumBits), the other property will take a negative value
        // If InputNumBits is given, you need to calculate and set InputLevel value and vice versa
        public int InputLevel { get; set; }
        public int InputNumBits { get; set; }
        public Signal InputSignal { get; set; }
        public Signal OutputQuantizedSignal { get; set; }
        public List<int> OutputIntervalIndices { get; set; }
        public List<string> OutputEncodedSignal { get; set; }
        public List<float> OutputSamplesError { get; set; }

        public override void Run()
        {
            if (InputNumBits == 0)
            {
                InputNumBits = (int)Math.Log(InputLevel, 2);
            }
            else if (InputLevel == 0)
            {
                InputLevel = (int)Math.Pow(2, InputNumBits);
            }
            OutputIntervalIndices = new List<int>();
            OutputEncodedSignal = new List<string>();
            OutputSamplesError = new List<float>();

            float slot1 = (InputSignal.Samples.Max() - InputSignal.Samples.Min()) / InputLevel;        // (max - min)/L
            List<float> l = new List<float>();               // level 
            List<float> midpoint = new List<float>(); ;      // mid of level
            l.Add(InputSignal.Samples.Min());
            for (int i = 1; i <= InputLevel; i++) { l.Add(l[i - 1] + slot1); }
            for (int i = 0; i < InputLevel; i++)
            {
                midpoint.Add((l[i] + l[i + 1]) / 2);
            }

            List<float> samples3 = new List<float>();
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                for (int j = 0; j < InputLevel; j++)
                {
                    if (InputSignal.Samples[i] >= l[j] && InputSignal.Samples[i] <= l[j + 1] + 0.0001)
                    {
                        samples3.Add(midpoint[j]);
                        OutputEncodedSignal.Add(Convert.ToString(j, 2).PadLeft(InputNumBits, '0'));
                        OutputIntervalIndices.Add(j + 1);
                        break;
                    }
                }
            }
            OutputQuantizedSignal = new Signal(samples3, false);

            List<float> samples = new List<float>();
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                samples.Add(OutputQuantizedSignal.Samples[i] - InputSignal.Samples[i]);
            }
            OutputSamplesError = samples;
        }
    }
}
