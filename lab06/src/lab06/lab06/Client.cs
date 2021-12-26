using System.Collections.Generic;

namespace lab06
{
    class Client : Obj
    {
        private Queue<double> _q;

        public Client(double a, double b, ref Queue<double> q) : base(a, b) 
        {
            _q = q;
        }

        public override void AddToQueue(double elem)
        {
            _q.Enqueue(elem);
        }
    }
}
