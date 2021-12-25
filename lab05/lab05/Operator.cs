using System.Collections.Generic;

namespace lab05
{
    class Operator : Obj
    {
        private Queue<double> _q;

        public Operator(double a, double b, ref Queue<double> q) : base(a, b)
        {
            _q = q;
        }

        public override void AddToQueue(double elem)
        {
            _q.Enqueue(elem);
        }
    }
}
