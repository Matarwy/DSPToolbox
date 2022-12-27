using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class FastCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }

        public override void Run()
        {
            float sum1 = 0, sum2 = 0, result;
            float pi = (float)Math.PI;
            int N = InputSignal1.Samples.Count;

            
            List<Complex> product = new List<Complex>();
            List<Complex> complex1 = new List<Complex>();
            List<Complex> complex2 = new List<Complex>();

            List<float> Normalized = new List<float>();
            List<float> nonNormalized = new List<float>();


            if (InputSignal2 == null)
                InputSignal2 = InputSignal1;

            for (int k = 0; k < N; k++)
            {
                float cosSignal1 = 0, sinSignal1 = 0, cosSignal2 = 0, sinSignal2 = 0;
                for (int n = 0; n < N; n++)
                {
                    float cos = (float)Math.Cos((2 * pi * k * n) / N);
                    float sin = -((float)Math.Sin((2 * pi * k * n) / N));

                    cosSignal1 += InputSignal1.Samples[n] * cos;
                    sinSignal1 += InputSignal1.Samples[n] * sin;

                    cosSignal2 += InputSignal2.Samples[n] * cos;
                    sinSignal2 += InputSignal2.Samples[n] * sin;
                }
                Complex num1 = new Complex(cosSignal1, sinSignal1);
                complex1.Add(num1);

                Complex num2 = new Complex(cosSignal2, sinSignal2);
                complex2.Add(num2);
            }

            for (int i = 0; i < N; i++)
            {
                sum1 += (float)Math.Pow(InputSignal1.Samples[i], 2);
                sum2 += (float)Math.Pow(InputSignal2.Samples[i], 2);
                product.Add(complex1[i] * Complex.Conjugate(complex2[i]));
            }
            result = (float)Math.Sqrt(sum1 * sum2) / N;

            for (int k = 0; k < N; k++)
            {
                float sum;
                Complex number = 0;

                for (int n = 0; n < N; n++)
                {
                    number += (product[n].Real * (Math.Cos(2 * pi * n * k / N))) + (product[n].Imaginary * (Math.Sin(2 * pi * n * k / N)));
                }

                sum = (float)((number.Real + number.Imaginary) / N);
                nonNormalized.Add(sum / N);
                Normalized.Add(sum / (N * result));
            }

            OutputNonNormalizedCorrelation = new List<float>(nonNormalized);
            OutputNormalizedCorrelation = new List<float>(Normalized);
        }
        }
    }