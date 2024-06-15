
namespace SCADACore.Infrastructure.Service
{
    public interface IAuthenticationService
    {
        string Login(string username, string password);

        bool Register(string username, string password);

        bool Logout(string token);

        bool IsAuthenticated(string token);
    }
}