using System;
using System.Collections.Generic;


namespace ComputingDevice
{
    class Device
    {
        private static Random rnd;
        private static int doneTasks;

        public Device()
        {
            rnd = new Random();
            doneTasks = 10000;
        }

        public void ProcessByTime(double a, double b, double m, double s, double rvr, ref int maxQueue, out bool flag)
        {
            Generator gnr = new Generator(a, b);
            ServiceMachine mch = new ServiceMachine(m, s);
            Queue<double> q = new Queue<double>();

            int numTasks = 0;
            double curTime = 0, gnrTime = gnr.Get(), srvTime = 0, step = 1;
            double srvTask;


            do
            {
                while (gnrTime <= curTime)
                {
                    q.Enqueue(gnrTime);
                    gnrTime += gnr.Get();
                }

                if (q.Count > maxQueue) maxQueue = q.Count;

                while (srvTime <= curTime && q.Count != 0)
                {
                    srvTask = q.Dequeue();
                    if (srvTime < srvTask)
                        srvTime = srvTask;

                    srvTime += mch.Get();
                    numTasks += 1;

                    if (isReverse(rvr))
                    {
                        srvTask = srvTime;
                        q.Enqueue(srvTask);
                    }
                }

                curTime += step;
            } while (numTasks < doneTasks);

            flag = maxQueue > 0.1 * doneTasks ? true : false;
        }

        private static bool isReverse(double rvr)
        {
            double p = rnd.NextDouble();

            if (p < rvr)
                return true;

            return false;
        }

        public void ProcessByEvents(double a, double b, double m, double s, double rvr, ref int maxQueue, out bool flag)
        {
            Generator gnr = new Generator(a, b);
            ServiceMachine mch = new ServiceMachine(m, s);
            Queue<double> q = new Queue<double>();

            int numTasks = 0;
            double gnrTime = gnr.Get(), curTime = gnrTime, srvTime = 0;
            double srvTask;

            maxQueue = 0;

            do
            {
                if (gnrTime <= curTime)
                {
                    q.Enqueue(gnrTime);
                    gnrTime += gnr.Get();
                }

                if (q.Count > maxQueue) maxQueue = q.Count;

                if (srvTime <= curTime)
                {
                    if (q.Count == 0)
                    {
                        curTime = gnrTime;
                        continue;
                    }

                    srvTask = q.Dequeue();
                    if (srvTime < srvTask)
                        srvTime = srvTask;

                    srvTime += mch.Get();
                    numTasks += 1;

                    if (isReverse(rvr))
                    {
                        srvTask = srvTime;
                        q.Enqueue(srvTask);
                    }
                }

                curTime = gnrTime < srvTime ? gnrTime : srvTime;
            } while (numTasks < doneTasks);

            flag = maxQueue > 0.1 * doneTasks ? true : false;
        }

        class Generator
        {
            private static double _a;
            private static double _b;
            private static Random rnd;

            public Generator(double a, double b)
            {
                _a = a;
                _b = b;
                rnd = new Random();
            }

            public double Get()
            {
                return _a + (_b - _a) * rnd.NextDouble();
            }
        }

        class ServiceMachine
        {
            private static double _m;
            private static double _s;
            private static Random rnd;

            private MathNet.Numerics.Distributions.Normal n;

            public ServiceMachine(double m, double s)
            {
                _m = m;
                _s = s;
                rnd = new Random();
                n = new MathNet.Numerics.Distributions.Normal(_m, _s);
            }

            public double Get()
            {
                double s = 0, res;

                for (int i = 0; i < 12; i++)
                    s += rnd.NextDouble();

                res = _m + (s - 6) * _s;
                if (res < 0)
                    res = Get();

                return res;

                //return n.Sample();
            }
        }
    }
}
