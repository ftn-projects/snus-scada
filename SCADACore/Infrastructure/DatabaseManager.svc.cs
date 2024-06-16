using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Service;
using System.Collections.Generic;

namespace SCADACore.Infrastructure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DatabaseManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DatabaseManager.svc or DatabaseManager.svc.cs at the Solution Explorer and start debugging.
    public class DatabaseManager : IDatabaseManager, IAuthenticationManager, ITagManager, IAlarmManager
    {
        private static IAuthenticationService _authenticationService = new AuthenticationService();
        private static ITagService _tagService = new TagService();

        public bool AddAlarmForTag(string token, string tagName, Alarm alarm)
        {
            if (!_authenticationService.IsAuthenticated(token)) return false;
            return _tagService.AddAlarmForTag(tagName, alarm);
        }

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
            return _tagService.ChangeOutputValue(tagName, newValue);
        }

        public List<Alarm> GetAlarmsForTag(string token, string tagName)
        {
            if (!_authenticationService.IsAuthenticated(token)) return null;
            return _tagService.GetAlarmsForTag(tagName);
        }

        public double GetOutputValue(string token, string tagName)
        {
            if (!_authenticationService.IsAuthenticated(token)) return 0;
            return _tagService.GetOutputValue(tagName);
            
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

        public bool RemoveAlarmForTag(string token, string tagName, string alarmName)
        {
            return _tagService.RemoveAlarmForTag(tagName, alarmName);
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
