using System.Collections.Generic;

namespace lab06
{
    class Operator : Obj
    {
        private Queue<double> _inQ;
        private Queue<double> _outQ;

        public Operator(double a, double b, ref Queue<double> inQ, ref Queue<double> outQ) : base(a, b)
        {
            _inQ = inQ;
            _outQ = outQ;
        }

        public override void AddToQueue(double elem)
        {
            _outQ.Enqueue(elem);
        }

        public override double GetFromQueue()
        {
            if (_inQ.Count != 0)
                return _inQ.Dequeue();
            return -1;
        }
    }
}
