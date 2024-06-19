using AlarmDisplay.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDisplay
{
    internal class Callback : IAlarmDisplayCallback
    {
        public void OnAlarmInvoked(AlarmInvocation alarm)
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
