using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Derivatives: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal FirstDerivative { get; set; }
        public Signal SecondDerivative { get; set; }

        public override void Run()
        {

            List<float> sampleFirst = new List<float>();
            List<float> sampleSecond = new List<float>();
            for (int i = 1; i < InputSignal.Samples.Count; i++)
            {
                sampleFirst.Add(InputSignal.Samples[i] - InputSignal.Samples[i - 1]);
                if (i == InputSignal.Samples.Count - 1)
                    sampleSecond.Add(0);
                else
                    sampleSecond.Add(InputSignal.Samples[i + 1] + InputSignal.Samples[i - 1] - (2 * InputSignal.Samples[i]));
            }
            FirstDerivative = new Signal(sampleFirst, false);
            SecondDerivative = new Signal(sampleSecond, false);
        }
    }
}
