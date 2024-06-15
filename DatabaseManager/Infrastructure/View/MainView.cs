using System;

namespace DatabaseManager.Infrastructure.View
{
    public class MainView
    {
        public string Token { get; set; }
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
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        AddTag();
                        break;
                    case "5":
                        RemoveTag();
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
            Console.WriteLine("[3] Turn scan on/off");
            Console.WriteLine("[4] Add tags");
            Console.WriteLine("[5] Remove tags");
            Console.WriteLine("[6] Register user");
            Console.WriteLine("[q] Logout/Quit");
        }   
        
        private void Register()
        {
            AuthenticationServiceReference.AuthenticationManagerClient authManager = new AuthenticationServiceReference.AuthenticationManagerClient();
            Console.WriteLine("Please enter your credentials: ");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            if(authManager.Register(username, password)) { Console.WriteLine("Registration successuful"); return; }
            Console.WriteLine("Registration failed");
        }

        private void Logout()
        {
            AuthenticationServiceReference.AuthenticationManagerClient authManager = new AuthenticationServiceReference.AuthenticationManagerClient();
            authManager.Logout(Token);
        }
        
        private void AddTag()
        {

        }

        private void RemoveTag()
        {

        }
    }
}
