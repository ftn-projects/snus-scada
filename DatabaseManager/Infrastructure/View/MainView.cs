using DatabaseManager.ServiceReference;
using System;
using DatabaseManager.Infrastructure.Service;

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
                        OpenAlarmMenu();
                        break;
                    case "7":
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
            Console.WriteLine("[5] Tag menu");
            Console.WriteLine("[6] Alarm menu");
            Console.WriteLine("[7] Register user");
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
            if(client.ChangeOutputValue(Token, tagName, newValue)) { Console.WriteLine("Ouput value changed"); return; }
            Console.WriteLine("Operation failed");
        }

        private void GetOutputValue()
        {
            DatabaseManagerClient client = new DatabaseManagerClient();
            string tagName = InputUtils.ReadStringNotEmpty("Tag name:");
            Console.WriteLine(client.GetOutputValue(Token, tagName)); 
        }
        
        private void OpenAlarmMenu()
        {
            new AlarmView(Token).Init();
        }
    }
}
