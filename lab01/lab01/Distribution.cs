using System;
using MathNet.Numerics;

namespace lab01
{
    class Distribution
    {
        public static void Equal(double a, double b, out double[] arrX, out double[] arrf, out double[] arrF)
        {
            double d = b - a;
            double step = d / 500;
            double x = a - d / 3;
            
            arrX = new double[(int)(5 * d / (3 * step)) + 1];
            arrf = new double[(int)(5 * d / (3 * step)) + 1];
            arrF = new double[(int)(5 * d / (3 * step)) + 1];

            if (a >= b)
                throw new Exception();

            for (int i = 0; i < arrX.Length; i++)
            {
                arrX[i] = Math.Round(x, 3);
                arrf[i] = _Equalf(a, b, x);
                arrF[i] = _EqualF(a, b, x);
                x += step;
            }
        }

        private static double _Equalf(double a, double b, double x)
        {
            return (a <= x && x <= b) ? 1 / (b - a) : 0;
        }

        private static double _EqualF(double a, double b, double x)
        {
            if (x < a) return 0;
            if (x > b) return 1;
            return (x - a) / (b - a);
        }

        public static void Normal(double mu, double sigma, out double[] arrX, out double[] arrf, out double[] arrF)
        {
            double a = -35, b = 35;
            double step = 1e-2;
            double x = a;

            arrX = new double[(int)((b - a) / step) + 1];
            arrf = new double[(int)((b - a) / step) + 1];
            arrF = new double[(int)((b - a) / step) + 1];

            for (int i = 0; i < arrX.Length; i++)
            {
                arrX[i] = Math.Round(x, 3);
                arrf[i] = _Normalf(mu, sigma, x);
                arrF[i] = _NormalF(mu, sigma, x);
                x += step;
            }
        }

        private static double _Normalf(double mu, double sigma, double x)
        {
            double pi = 3.14;

            return 1 / (sigma * Math.Sqrt(2 * pi)) * Math.Exp(-Math.Pow(x - mu, 2) / (2 * sigma * sigma));
        }

        private static double _NormalF(double mu, double sigma, double x)
        {
            return 0.5 * (1 + SpecialFunctions.Erf((x - mu) / (sigma * Math.Sqrt(2))));
        }

    }
}
