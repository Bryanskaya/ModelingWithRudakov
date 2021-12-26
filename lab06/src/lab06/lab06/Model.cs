using System.Collections.Generic;
using System.Linq;

namespace lab06
{
    class Model
    {
        public Queue<double>[] qArr;
        public Client[] clientArr;
        public Nurse[] nrsArr;
        public Doctor[] dctArr;
        public int[] maxSizeQ;

        public Operator opr;

        List<Event> eventArr;

        public int processed;
        public int refused;
        public double simTime;
        public double pRefuse;

        private static int _limit;
        private static int _maxQueue;


        public Model(int limit)
        {
            processed = 0;
            refused = 0;
            _limit = limit;
            _maxQueue = 7;

            eventArr = new List<Event>();

            qArr = new Queue<double>[]
            {
                new Queue<double>(),
                new Queue<double>(),
                new Queue<double>(),
                new Queue<double>()
            };

            clientArr = new Client[2]
            {
                new Client(5, 2, ref qArr[0]),
                new Client(6, 2, ref qArr[1])
            };

            opr = new Operator(5.5, 3, ref qArr[0], ref qArr[2]);

            nrsArr = new Nurse[3]
            {
                new Nurse(8, 2, ref qArr[2], ref qArr[3]),
                new Nurse(12, 4, ref qArr[2], ref qArr[3]),
                new Nurse(5, 2, ref qArr[1], ref qArr[3])
            };

            dctArr = new Doctor[2]
            {
                new Doctor(7, 2, ref qArr[3]),
                new Doctor(5, 1, ref qArr[3])
            };

            maxSizeQ = new int[4] { 0, 0, 0, 0 };
        }

        public void Imitation()
        {
            Event curEvent;

            eventArr.Add(new Event(EventType.IsClient1, clientArr[0].Next(), 0));
            eventArr.Add(new Event(EventType.IsClient2, clientArr[1].Next(), 1));

            while (eventArr.Count > 0)
            {
                eventArr.Sort((Event x, Event y) =>
                    x.etime > y.etime
                        ? 1 : -1);

                if (processed + refused >= _limit)
                    break;

                curEvent = eventArr[0];
                eventArr.RemoveAt(0);

                switch (curEvent.etype)
                {
                    case EventType.IsClient1:
                    case EventType.IsClient2:
                        ProcessClient(curEvent);
                        break;

                    case EventType.IsOperator:
                        ProcessOperator(curEvent);
                        break;

                    case EventType.IsNurse:
                        ProcessNurse(curEvent);
                        break;

                    case EventType.IsDoctor:
                        ProcessDoctor(curEvent);
                        break;
                }

                CountMaxQ();
            }

            simTime = eventArr[0].etime;
            pRefuse = CountPRefuse();
        }

        private void ProcessClient(Event e)
        {
            if (e.etype is EventType.IsClient1)
            {
                if (qArr[0].Count >= _maxQueue)
                {
                    refused += 1;
                    eventArr.Add(new Event(e.etype, clientArr[e.ind].Next(e.etime), e.ind));
                    return;
                }
            }

            if (e.etype is EventType.IsClient1)
            {
                if (opr.IsFree())
                {
                    eventArr.Add(new Event(EventType.IsOperator, e.etime));
                }

                qArr[0].Enqueue(e.etime);
            }
            else
            {
                if (nrsArr[2].IsFree())
                {
                    eventArr.Add(new Event(EventType.IsNurse, e.etime, 2));
                }

                qArr[1].Enqueue(e.etime);
            }

            eventArr.Add(new Event(e.etype, clientArr[e.ind].Next(e.etime), e.ind));
        }

        private void ProcessOperator(Event e)
        {
            double tempValue;

            if (!opr.IsFree())
            {
                opr.AddToQueue(e.etime);

                if (nrsArr[0].IsFree())
                    eventArr.Add(new Event(EventType.IsNurse, e.etime, 0));
                else if (nrsArr[1].IsFree())
                    eventArr.Add(new Event(EventType.IsNurse, e.etime, 1));
            }

            tempValue = opr.GetFromQueue();
            if (tempValue > 0)
            {
                opr.SetBusy();
                eventArr.Add(new Event(EventType.IsOperator, opr.Next(e.etime)));
            }
            else
            {
                opr.SetFree();
            }
        }

        private void ProcessNurse(Event e)
        {
            double tempValue;

            if (!nrsArr[e.ind].IsFree())
            {
                nrsArr[e.ind].AddToQueue(e.etime);

                if (dctArr[0].IsFree())
                    eventArr.Add(new Event(EventType.IsDoctor, e.etime, 0));
                else if (dctArr[1].IsFree())
                    eventArr.Add(new Event(EventType.IsDoctor, e.etime, 1));
            }

            tempValue = nrsArr[e.ind].GetFromQueue();
            if (tempValue > 0)
            {
                nrsArr[e.ind].SetBusy();
                eventArr.Add(new Event(EventType.IsNurse, nrsArr[e.ind].Next(e.etime), e.ind));
            }
            else
            {
                nrsArr[e.ind].SetFree();
            }
        }

        private void ProcessDoctor(Event e)
        {
            double tempValue;

            if (!dctArr[e.ind].IsFree())
            {
                processed += 1;
                dctArr[e.ind].SetFree();
            }

            tempValue = dctArr[e.ind].GetFromQueue();
            if (tempValue > 0)
            {
                dctArr[e.ind].SetBusy();
                eventArr.Add(new Event(EventType.IsDoctor, dctArr[e.ind].Next(e.etime), e.ind));
            }
        }

        private double CountPRefuse()
        {
            return (double)refused / (refused + processed);
        }

        private void CountMaxQ()
        {
            for (int i = 0; i < qArr.Count(); i++)
                if (qArr[i].Count() > maxSizeQ[i])
                    maxSizeQ[i] = qArr[i].Count();
        }
    }
}
