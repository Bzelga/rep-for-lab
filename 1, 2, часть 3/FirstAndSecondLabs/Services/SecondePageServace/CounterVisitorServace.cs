namespace FirstAndSecondLabs
{
    public class CounterVisitorServace : ICounter2
    {
        private int _count = 0;

        public CounterVisitorServace()
        {
            _count++;
        }
        public int Count
        {
            get { return _count++; }
        }
    }
}
