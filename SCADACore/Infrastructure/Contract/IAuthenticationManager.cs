using System.ServiceModel;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract] 
    internal interface IAuthenticationManager
    {
        [OperationContract]
        string Login(string username, string password);

        [OperationContract]
        bool Register(string username, string password);
        
        [OperationContract]
        bool Logout(string token);
    }
}
