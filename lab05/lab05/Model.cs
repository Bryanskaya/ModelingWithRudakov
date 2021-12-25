using System.Collections.Generic;

namespace lab05
{
    class ModelInfo
    {
        public Client clients;
        public Operator[] oprArr;
        public Computer[] comArr;
        public Queue<double> q1;
        public Queue<double> q2;
    }

    class Model : ModelInfo
    {
        private static int _goal;
        public int processed;
        public int refused;
        public double simTime;
        public double pRefuse;

        List<Event> eventArr;

        public Model(int goal)
        {
            processed = 0;
            refused = 0;
            q1 = new Queue<double>();
            q2 = new Queue<double>();
            eventArr = new List<Event>();

            clients = new Client(8, 12);
            comArr = new Computer[2]
            {
                new Computer(15, ref q1),
                new Computer(30, ref q2)
            };

            oprArr = new Operator[3]
            {
                new Operator(15, 25, ref q1),
                new Operator(30, 50, ref q1),
                new Operator(20, 60, ref q2)
            };

            _goal = goal;
        }

        public void Imitation()
        {
            Event curEvent;

            eventArr.Add(new Event(EventType.IsClient, clients.Next()));

            while (eventArr.Count > 0)
            {
                if (refused + processed >= _goal)
                    break;

                curEvent = eventArr[0];
                eventArr.RemoveAt(0);

                if (curEvent.etype is EventType.IsClient)   ProcessClient(curEvent);
                else if (curEvent.etype is EventType.IsOperator)    ProcessOperator(curEvent);
                else    ProcessComputer(curEvent);

                eventArr.Sort((Event x, Event y) =>
                    x.etime > y.etime
                        ? 1 : -1);
            }

            simTime = eventArr[0].etime;
            pRefuse = CountPRefuse();
        }

        private void ProcessClient(Event e)
        {
            int refuse = 1;

            for (int i = 0; i < oprArr.Length; i++)
            {
                if (oprArr[i].IsFree())
                {
                    eventArr.Add(new Event(EventType.IsOperator, oprArr[i].Next(e.etime), i));
                    oprArr[i].SetBusy();
                    refuse = 0;
                    break;
                }
            }

            refused += refuse;

            eventArr.Add(new Event(EventType.IsClient, clients.Next(e.etime)));
        }

        private void ProcessOperator(Event e)
        {
            int temp;

            oprArr[e.ind].AddToQueue(e.etime);

            temp = (e.ind == 2) ? 1 : 0;

            if (comArr[temp].IsFree())
            {
                eventArr.Add(new Event(EventType.IsComputer, e.etime, temp));
                processed -= 1;
            }

            oprArr[e.ind].SetFree();
            oprArr[e.ind].next = 0;
        }

        private void ProcessComputer(Event e)
        {
            double tempValue;

            tempValue = comArr[e.ind].GetFromQueue();
            if (tempValue > 0)
            {
                comArr[e.ind].SetBusy();
                eventArr.Add(new Event(EventType.IsComputer, comArr[e.ind].Next(e.etime), e.ind));
            }
            else
                comArr[e.ind].SetFree();

            processed += 1;
        }

        private double CountPRefuse()
        {
            return (double)refused / (refused + processed);
        }
    }
}
