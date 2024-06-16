using DatabaseManager.ServiceReference;
using System;
using Infrastructure.Service.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseManager.Infrastructure.View
{
    public class MainView
    {
        private string Token { get; set; }
        public MainView() { }
        public MainView(string token)
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
                        ChangeOutputValue();
                        break;
                    case "2":
                        GetOutputValue();
                        break;
                    case "3":
                        TurnScanOn();
                        break;
                    case "4":
                        TurnScanOff();
                        break;
                    case "5":
                        TagMenu();
                        break;
                    case "6":
                        AddAlarmToTag();
                        break;
                    case "7":
                        RemoveAlarmFromTag();
                        break;
                    case "8":
                        ListAlarmForTag();
                        break;
                    case "9":
                        Register();
                        break;
                    default:
                        break;
                }

            } while (!string.Equals(option, "q", StringComparison.OrdinalIgnoreCase));
            Logout();
        }

        public void PrintMenu() 
        {
            Console.WriteLine("[1] Change output value");
            Console.WriteLine("[2] Get output value");
            Console.WriteLine("[3] Turn scan on");
            Console.WriteLine("[4] Turn scan off");
            Console.WriteLine("[5] Add/Remove tags");
            Console.WriteLine("[6] Add alarm");
            Console.WriteLine("[7] Remove alarm");
            Console.WriteLine("[8] List alarm for tag");
            Console.WriteLine("[9] Register user");
            Console.WriteLine("[q] Logout/Quit");
        }   
        
        private void Register()
        {
            AuthenticationManagerClient authManager = new AuthenticationManagerClient();
            Console.WriteLine("Please enter your credentials: ");
            string username = InputUtils.ReadStringNotEmpty("Username:"); 
            string password = InputUtils.ReadStringNotEmpty("Password:");
            if(authManager.Register(username, password)) { Console.WriteLine("Registration successuful"); return; }
            Console.WriteLine("Registration failed");
        }

        private void Logout()
        {
            AuthenticationManagerClient authManager = new AuthenticationManagerClient();
            authManager.Logout(Token);
        }
        
        private void TagMenu()
        {
            new TagView(Token).Init();
        }
        
        private void TurnScanOn()
        {
            string tagName = InputUtils.ReadStringNotEmpty("Enter tag name:");
            DatabaseManagerClient client = new DatabaseManagerClient();
            if(client.TurnScanOn(Token, tagName)) { Console.WriteLine($"Scan turned on successfully on tag {tagName}"); return; }
            Console.WriteLine("Operation failed");
        }

        private void TurnScanOff()
        {
            string tagName = InputUtils.ReadStringNotEmpty("Enter tag name:");
            DatabaseManagerClient client = new DatabaseManagerClient();
            if(client.TurnScanOff(Token, tagName)) { Console.WriteLine($"Scan turned off successfully on tag {tagName}"); return; }
            Console.WriteLine("Operation failed");
        }

        private void ChangeOutputValue()
        {
            DatabaseManagerClient client = new DatabaseManagerClient();
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            double newValue = InputUtils.ReadDouble("New value:");
            client.ChangeOutputValue(Token, tagName, newValue);
        }

        private void GetOutputValue()
        {
            DatabaseManagerClient client = new DatabaseManagerClient();
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            Console.WriteLine(client.GetOutputValue(Token, tagName)); 
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
            client.AddAlarmForTag(Token, tagName, alarm);
        }

        private void RemoveAlarmFromTag() 
        {
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            string alarmName = InputUtils.ReadStringNotEmpty("Alarm name:");
            
            AlarmManagerClient client = new AlarmManagerClient();
            client.RemoveAlarmForTag(Token, tagName, alarmName);
        }

        private void ListAlarmForTag()
        {
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            AlarmManagerClient client = new AlarmManagerClient();
            List<Alarm> alarms = client.GetAlarmsForTag(Token, tagName).ToList();
            return;
        }
    }
}
