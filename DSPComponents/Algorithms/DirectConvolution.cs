using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            int indiceBegin = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];

            List<float> samples = new List<float>();
            List<int> indices = new List<int>();
            for(int i =0; i < ((InputSignal1.Samples.Count + InputSignal2.Samples.Count) -1); i++)
            {
                samples.Add(0);
                for (int j =0; j< InputSignal1.Samples.Count; j++)
                {
                    if(((i-j) >= 0) && ((i-j) < InputSignal2.Samples.Count))
                    {
                        samples[i] += InputSignal2.Samples[i - j] * InputSignal1.Samples[j];
                    } 
                }

                indices.Add(indiceBegin);
                indiceBegin++;
                Console.WriteLine(indices[i]);
                Console.WriteLine(samples[i]);
            }
            while (samples[samples.Count - 1] == 0)
            {
                samples.RemoveAt(samples.Count - 1);
                indices.RemoveAt(indices.Count - 1);
            }

            while (samples[0] == 0)
            {
                samples.RemoveAt(0);
                indices.RemoveAt(0);
            }
            OutputConvolvedSignal = new Signal(samples, indices, false);
        }
    }
}
