using System;

namespace FirstAndSecondLabs
{
    public class RandomNumberServace : ICounter3
    {
        private int _count;
        private Random rnd = new Random();

        public RandomNumberServace()
        {
            _count = rnd.Next(-100, 100);
        }

        public int Count
        {
            get { return _count; }
        }
    }
}
