using System.Collections.Generic;

namespace lab06
{
    class Nurse : Operator
    {
        public Nurse(double a, double b, ref Queue<double> inQ, ref Queue<double> outQ) : base(a, b, ref inQ, ref outQ) {}
    }
}
