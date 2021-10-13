using System;

namespace FirstAndSecondLabs
{
    public class CounterService : ICounter1
    {
        public int Count 
        { 
            get { return 100; } 
        }
    }
}
