using System;

namespace lab06
{
    class Obj : Generator
    {
        public bool _isFree;
        public double next;

        public Obj(double a, double b) : base(a, b)
        {
            SetFree();
            next = 0;
        }

        public double Next(double cur_time = 0)
        {
            next = cur_time + ProcessTime();
            return next;
        }

        public bool IsFree() { return _isFree; }
        public void SetFree() { _isFree = true; }
        public void SetBusy() { _isFree = false; }
        public virtual void AddToQueue(double elem) { throw new Exception(); }
        public virtual double GetFromQueue() { throw new Exception(); }
    }
}
