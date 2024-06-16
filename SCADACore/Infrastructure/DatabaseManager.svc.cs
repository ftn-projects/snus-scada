using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Service;

namespace SCADACore.Infrastructure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DatabaseManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DatabaseManager.svc or DatabaseManager.svc.cs at the Solution Explorer and start debugging.
    public class DatabaseManager : IDatabaseManager, IAuthenticationManager, ITagManager
    {
        private static IAuthenticationService _authenticationService = new AuthenticationService();
        private static ITagService _tagService = new TagService();

        public bool AddAnalogInputTag(string token, AnalogInputTag analogInputTag)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            _tagService.AddAnalogInputTag(analogInputTag);
            return true;
        }

        public bool AddAnalogOutputTag(string token, AnalogOutputTag analogOutputTag)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            _tagService.AddAnalogOutputTag(analogOutputTag);
            return true;
        }

        public bool AddDigitalInputTag(string token, DigitalInputTag digitalInputTag)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            _tagService.AddDigitalInputTag(digitalInputTag);
            return true;
        }

        public bool AddDigitalOutputTag(string token, DigitalOutputTag digitalOutputTag)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            _tagService.AddDigitalOutputTag(digitalOutputTag);
            return true;
        }

        public bool ChangeOutputValue(string token, string tagName, double newValue)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            throw new System.NotImplementedException();
        }

        public bool GetOutputValue(string token, string tagName)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            throw new System.NotImplementedException();
        }

        public TagsState GetTagsState(string token)
        {
            return _tagService.GetTagsState();
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

        public bool RemoveTag(string token, string TagName)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            return _tagService.RemoveTag(TagName);
        }

        public bool TurnScanOff(string token, string tagName)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            return _tagService.TurnScanOff(tagName);
        }

        public bool TurnScanOn(string token, string tagName)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            return _tagService.TurnScanOn(tagName);
        }
    }
}
