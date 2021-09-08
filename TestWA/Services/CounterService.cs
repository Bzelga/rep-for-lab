using System;

namespace TestWA.Services
{
    public class CounterService : ICounter
    {
        private int _count;
        private Random rnd = new Random();

        public CounterService()
        {
            _count = rnd.Next(0,100);
        }

        public int Count 
        { 
            get { return _count; } 
        }
    }
}
