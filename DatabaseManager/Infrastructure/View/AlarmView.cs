using DatabaseManager.ServiceReference;
using Infrastructure.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Infrastructure.View
{
    public class AlarmView
    {
        private string Token { get; set; }

        public AlarmView(string token) 
        {
            Token = token;
        }
        

        public void Init()
        {
            string option;
            do
            {
                PrintMenu();
                option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        AddAlarmToTag();
                        break;
                    case "2":
                        RemoveAlarmFromTag();
                        break;
                    case "3":
                        ListAlarmForTag();
                        break;
                    default:
                        break;
                }

            } while (!string.Equals(option, "q", StringComparison.OrdinalIgnoreCase));
        }
        private void PrintMenu()
        {
            Console.WriteLine("[1] Add alarm to tag");
            Console.WriteLine("[2] Remove alarm from tag");
            Console.WriteLine("[3] List alarms on tag");
            Console.WriteLine("[q] Back");
        } 
        private void AddAlarmToTag()
        {
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            Alarm alarm = new Alarm();
            alarm.Name = InputUtils.ReadStringNotEmpty("Alarm name (must be unique):");
            alarm.AlarmType = InputUtils.ReadOption<AlarmType>(new AlarmType[] { AlarmType.Low, AlarmType.High }, "Select the alarm's type");
            alarm.Priority = InputUtils.ReadOption<Priority>(new Priority[] {Priority.Low, Priority.Medium, Priority.High}, "Select the alarm's priority");
            alarm.LimitValue = InputUtils.ReadDouble("Limit value:");
            alarm.Units = InputUtils.ReadStringNotEmpty("Units:");
            AlarmManagerClient client = new AlarmManagerClient();
            if(client.AddAlarmForTag(Token, tagName, alarm)) { Console.WriteLine("New alarm added to the tag"); return; }
            Console.WriteLine("Operation failed");
        }

        private void RemoveAlarmFromTag() 
        {
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            string alarmName = InputUtils.ReadStringNotEmpty("Alarm name:");
            
            AlarmManagerClient client = new AlarmManagerClient();
            if(client.RemoveAlarmForTag(Token, tagName, alarmName)) { Console.WriteLine("Alarm removed successfully"); return; }
            Console.WriteLine("Operation failed");
        }

        private void ListAlarmForTag()
        {
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            AlarmManagerClient client = new AlarmManagerClient();
            List<Alarm> alarms = client.GetAlarmsForTag(Token, tagName).ToList();
            string message =  alarms.Count() > 0? $"Alarms for {tagName} tag" : $"No alarms found for given tag name: {tagName}";
            Console.WriteLine(message);
            foreach(var alarm in alarms)
            {
                Console.WriteLine($"\nAlarm name: {alarm.Name}");                
                Console.WriteLine($"Alarm type: {alarm.AlarmType}");                
                Console.WriteLine($"Limit value: {alarm.LimitValue}");
                Console.WriteLine($"Units: {alarm.Units}");
                Console.WriteLine($"Priority: {alarm.Priority}\n");                
            }
        }
    }
}
