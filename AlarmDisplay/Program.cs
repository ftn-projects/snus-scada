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
        public void OnAlarmInvoked(AlarmInvocation a)
        {

            var delta = (a.LimitDeltaValue > 0 ? "+" : "") + $"{a.LimitDeltaValue}";
            Console.WriteLine($"[{a.Timestamp}] {a.TagName} {a.Name} {a.Limit + a.LimitDeltaValue} ({delta})");
        }
    }

    internal class Program
    {
        static void Main()
        {
            var ic = new InstanceContext(new Callback());
            var client = new AlarmDisplayClient(ic);

            Console.WriteLine("\n---------------Alarm Display---------------");

            client.InitAlarmDisplay();
            Console.ReadKey();
        }
    }
}
