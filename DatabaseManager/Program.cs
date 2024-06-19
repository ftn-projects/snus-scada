using DatabaseManager.Infrastructure.View;

namespace DatabaseManager
{
    internal class Program
    {
        static void Main()
        {
            LoginView view = new LoginView();
            view.Init();
        }
    }
}
