namespace lab05
{
    public enum EventType
    {
        IsClient,
        IsOperator,
        IsComputer
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
