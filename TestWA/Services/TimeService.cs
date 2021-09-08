using System;

namespace TestWA.Services
{
    public class TimeService : ITimeSender
    {
        private string _dateTime;
        public TimeService()
        {
            _dateTime = DateTime.Now.ToString("HH.mm.ss");
        }

        public string DataTime
        {
            get { return _dateTime; }
        }
    }
}
