using System;

namespace DatabaseManager.Infrastructure.View
{
    public class LoginView
    {
        public LoginView() { }
        public void Init()
        {
            Console.WriteLine("Database Manager");
            string option;
            do
            {
                PrintMenu();
                option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register(); 
                        break;
                    default:
                        break;
                }

            } while (!string.Equals(option, "q", StringComparison.OrdinalIgnoreCase));
        }
        private void PrintMenu()
        {
            Console.WriteLine("[1] Login");
            Console.WriteLine("[2] Register");
            Console.WriteLine("[q] Quit");
        }

        private void Login()
        {
            AuthenticationServiceReference.AuthenticationManagerClient authManager = new AuthenticationServiceReference.AuthenticationManagerClient();
            Console.WriteLine("Please enter your credentials: ");
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            string token = authManager.Login(username, password);
            
            if(string.IsNullOrEmpty(token)) 
            { 
                Console.WriteLine("Login Failed");
                return;
            }

            new MainView(token).Init(); 
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
    }
}
