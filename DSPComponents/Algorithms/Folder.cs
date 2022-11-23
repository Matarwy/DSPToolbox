using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            List<float> samples = new List<float>();
            List<int> indecies = new List<int>();
            for(int i = (InputSignal.SamplesIndices.Count -1); i >= 0;i--)
            {
                indecies.Add(InputSignal.SamplesIndices[i]*(-1));
                samples.Add(InputSignal.Samples[i]);
            }
            OutputFoldedSignal = new Signal(samples, indecies, false);
        }
    }
}
