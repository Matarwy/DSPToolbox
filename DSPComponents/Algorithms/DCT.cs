using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DCT: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> values = new List<float>();
            int N = InputSignal.Samples.Count();
            double alpha = Math.Sqrt((double)2 / N);

            for (int k = 0; k < N; k++)
            {
                float sum = 0;

                for (int n = 0; n < N; n++)
                {
                    sum += (float)InputSignal.Samples[n] * (float)Math.Cos(Math.PI / (4 * N) * (2 * n - 1) * (2 * k - 1));
                }

                values.Add((float)alpha * sum);
            }

            OutputSignal = new Signal(values, false);
        }
    }
}
