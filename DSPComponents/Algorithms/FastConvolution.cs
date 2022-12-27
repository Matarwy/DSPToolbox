using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class FastConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            List<float> values = new List<float>();
            List<Complex> product = new List<Complex>();
            List<Complex> complex1 = new List<Complex>();
            List<Complex> complex2 = new List<Complex>();

            int difference = InputSignal1.Samples.Count + InputSignal2.Samples.Count - 1;
            for (int i = InputSignal1.Samples.Count; i < difference; i++)
            {
                InputSignal1.Samples.Add(0);
            }
            for (int i = InputSignal2.Samples.Count; i < difference; i++)
            {
                InputSignal2.Samples.Add(0);
            }

            float pi = (float)Math.PI;
            int N = InputSignal1.Samples.Count;

            for (int k = 0; k < N; k++)
            {
                float cosSignal1 = 0, sinSignal1 = 0, cosSignal2 = 0, sinSignal2 = 0;
                for (int n = 0; n < N; n++)
                {
                    float cos = (float)Math.Cos((2 * pi * k * n) / N);
                    float sin = -((float)Math.Sin((2 * pi * k * n) / N));

                    cosSignal1 += (InputSignal1.Samples[n] * cos);
                    sinSignal1 += (InputSignal1.Samples[n] * sin);

                    cosSignal2 += (InputSignal2.Samples[n] * cos);
                    sinSignal2 += (InputSignal2.Samples[n] * sin);
                }
                Complex num1 = new Complex(cosSignal1, sinSignal1);
                complex1.Add(num1);

                Complex num2 = new Complex(cosSignal2, sinSignal2);
                complex2.Add(num2);
            }

            for (int i = 0; i < N; i++)
            {
                product.Add(complex1[i] * complex2[i]);
            }

            for (int k = 0; k < N; k++)
            {
                Complex number = 0;
                for (int n = 0; n < N; n++)
                {
                    number += (product[n].Real * (Math.Cos(2 * pi * n * k / N))) + (product[n].Imaginary * (-Math.Sin(2 * pi * n * k / N)));
                }

                values.Add((float)((number.Real + number.Imaginary) / N));
            }

            OutputConvolvedSignal = new Signal(values, true);
        }
    }
}
