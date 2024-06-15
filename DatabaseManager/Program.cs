using DatabaseManager.Infrastructure.View;

namespace DatabaseManager
{
    internal class Program
    {
        static AuthenticationServiceReference.AuthenticationManagerClient authService = new AuthenticationServiceReference.AuthenticationManagerClient();
        static void Main(string[] args)
        {
            LoginView view = new LoginView();
            view.Init();
        }
    }
}
