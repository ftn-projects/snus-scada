using SCADACore.Infrastructure.Service;

namespace SCADACore.Infrastructure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DatabaseManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DatabaseManager.svc or DatabaseManager.svc.cs at the Solution Explorer and start debugging.
    public class DatabaseManager : IDatabaseManager, IAuthenticationManager
    {
        private static IAuthenticationService _authenticationService = new AuthenticationService();

        public void DoWork()
        {
        
        }

        public string Login(string username, string password)
        {
            return _authenticationService.Login(username, password); 
        }
        public bool Logout(string token)
        {
            return _authenticationService.Logout(token);
        }

        public bool Register(string username, string password)
        {
            return _authenticationService.Register(username, password);
        }
    }
}
