using AlarmDisplay.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDisplay
{
    internal class Callback : IAlarmDisplayCallback
    {
        public void OnAlarmInvoked(AlarmInvocation alarm)
        {
            Console.WriteLine(alarm.ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var ic = new InstanceContext(new Callback());
            var client = new AlarmDisplayClient(ic);

            Console.WriteLine("\n---------------Alarm Display---------------");

            client.InitAlarmDisplay();
            Console.ReadKey();
        }
    }
}
