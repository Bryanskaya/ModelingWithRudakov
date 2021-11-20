using System;
using System.Linq;
using MathNet.Numerics.Distributions;

namespace calculations
{
    class MathCalc
    {
        public static double Criteria(int[] arr, int elMin, int elMax)
        {
            double y = 0, p = 1.0 / (elMax - elMin);

            for (int i = elMin; i < elMax; i++)
                y += Math.Pow(arr.Count(x => x == i), 2) / p;

            y = y / (double)arr.Length - arr.Length;

            return ChiSquared.CDF(elMax - elMin - 1, y);
        }
    }
}
