using DatabaseManager.Infrastructure.View;

namespace DatabaseManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginView view = new LoginView();
            view.Init();
        }
    }
}
