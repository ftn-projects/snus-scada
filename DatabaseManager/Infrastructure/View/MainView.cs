using SCADACore.Infrastructure.Utils;
using System;

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
            Console.WriteLine("[6] Register user");
            Console.WriteLine("[q] Logout/Quit");
        }   
        
        private void Register()
        {
            AuthenticationServiceReference.AuthenticationManagerClient authManager = new AuthenticationServiceReference.AuthenticationManagerClient();
            Console.WriteLine("Please enter your credentials: ");
            string username = InputUtils.ReadStringNotEmpty("Username:"); 
            string password = InputUtils.ReadStringNotEmpty("Password:");
            if(authManager.Register(username, password)) { Console.WriteLine("Registration successuful"); return; }
            Console.WriteLine("Registration failed");
        }

        private void Logout()
        {
            AuthenticationServiceReference.AuthenticationManagerClient authManager = new AuthenticationServiceReference.AuthenticationManagerClient();
            authManager.Logout(Token);
        }
        
        private void TagMenu()
        {
            new TagView(Token).Init();
        }
        
        private void TurnScanOn()
        {

        }

        private void TurnScanOff()
        {
            string tagName = InputUtils.ReadStringNotEmpty();
        }

        private void ChangeOutputValue()
        {

        }

        private void GetOutputValue()
        {

        }
    }
}
