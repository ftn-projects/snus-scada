using System.ServiceModel;

namespace SCADACore.Infrastructure
{
    [ServiceContract] 
    internal interface IAuthenticationManager
    {
        [OperationContract(IsOneWay = false)]
        string Login(string username, string password);

        [OperationContract(IsOneWay = false)]
        bool Register(string username, string password);
        
        [OperationContract(IsOneWay = false)]
        bool Logout(string token);
    }
}
