namespace lab06
{
    public enum EventType
    {
        IsClient1,
        IsClient2,
        IsOperator,
        IsNurse,
        IsDoctor
    }

    class Event
    {
        public EventType etype;
        public double etime;
        public int ind;

        public Event(EventType type, double time, int index = 0)
        {
            etype = type;
            etime = time;
            ind = index;
        }
    }
}
