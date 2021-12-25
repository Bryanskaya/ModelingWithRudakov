using System.Collections.Generic;

namespace lab05
{
    class Computer : Obj
    {
        private Queue<double> _q;

        public Computer(double a, ref Queue<double> q) : base(a, a)
        {
            _q = q;
        }

        public override double GetFromQueue()
        {
            if (_q.Count != 0)
                return _q.Dequeue();
            return -1;
        }
    }
}
