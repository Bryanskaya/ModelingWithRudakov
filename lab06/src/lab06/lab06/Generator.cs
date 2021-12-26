using System;

namespace lab06
{
    class Generator
    {
        private double _a;
        private double _b;
        private static Random rnd = new Random();

        public Generator(double m, double d)
        {
            _a = m - d;
            _b = m + d;
        }

        public double ProcessTime()
        {
            return _a + (_b - _a) * rnd.NextDouble();
        }
    }
}
