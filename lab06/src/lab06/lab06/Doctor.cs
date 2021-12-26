using System.Collections.Generic;

namespace lab06
{
    class Doctor : Obj
    {
        private Queue<double> _inQ;

        public Doctor(double a, double b, ref Queue<double> inQ) : base(a, b) 
        {
            _inQ = inQ;
        }

        public override double GetFromQueue()
        {
            if (_inQ.Count != 0)
                return _inQ.Dequeue();
            return -1;
        }
    }
}    