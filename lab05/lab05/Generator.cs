using System;

namespace lab05
{
    class Generator
    {
        private double _a;
        private double _b;
        private Random rnd;

        public Generator(double a, double b)
        {
            _a = a;
            _b = b;
            rnd = new Random();
        }

        public double ProcessTime()
        {
            return _a + (_b - _a) * rnd.NextDouble();
        }
    }
}
