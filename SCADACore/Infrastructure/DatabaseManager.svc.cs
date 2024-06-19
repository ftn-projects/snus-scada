using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Service;
using System.Collections.Generic;
using SCADACore.Infrastructure.Contract;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using SCADACore.Infrastructure.Repository;

namespace SCADACore.Infrastructure
{
    public class DatabaseManager : IDatabaseManager, IAuthenticationManager, ITagManager, IAlarmManager
    {
        private static readonly IAuthenticationService AuthenticationService = new AuthenticationService();
        private static readonly ITagService TagService = new TagService();

        public bool AddAlarmForTag(string token, string tagName, Alarm alarm)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            return TagService.AddAlarmForTag(tagName, alarm);
        }

        public bool AddAnalogInputTag(string token, AnalogInputTag analogInputTag)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            TagService.AddTag(analogInputTag);
            Processing.AddTagScan(analogInputTag);
            return true;
        }

        public bool AddAnalogOutputTag(string token, AnalogOutputTag analogOutputTag)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            TagService.AddTag(analogOutputTag);
            return true;
        }

        public bool AddDigitalInputTag(string token, DigitalInputTag digitalInputTag)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            TagService.AddTag(digitalInputTag);
            Processing.AddTagScan(digitalInputTag);
            return true;
        }

        public bool AddDigitalOutputTag(string token, DigitalOutputTag digitalOutputTag)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            TagService.AddTag(digitalOutputTag);
            return true;
        }

        public bool ChangeOutputValue(string token, string tagName, double newValue)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            return TagService.ChangeOutputValue(tagName, newValue);
        }

        public List<Alarm> GetAlarmsForTag(string token, string tagName)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return null;
            return TagService.GetAlarmsForTag(tagName);
        }

        public double GetOutputValue(string token, string tagName)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return 0;
            return TagService.GetOutputValue(tagName);
            
        }

        public TagsState GetTagsState(string token)
        {
            return TagService.GetTagsState();
        }

        public string Login(string username, string password)
        {
            return AuthenticationService.Login(username, password); 
        }
        public bool Logout(string token)
        {
            return AuthenticationService.Logout(token);
        }

        public bool Register(string username, string password)
        {
            return AuthenticationService.Register(username, password);
        }

        public bool RemoveAlarmForTag(string token, string tagName, string alarmName)
        {
            return TagService.RemoveAlarmForTag(tagName, alarmName);
        }

        public bool RemoveTag(string token, string tagName)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            Processing.RemoveTagScan(tagName);
            return TagService.RemoveTag(tagName);
        }

        public bool TurnScanOff(string token, string tagName)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            Processing.RemoveTagScan(tagName);
            return TagService.TurnScanOff(tagName);
        }

        public bool TurnScanOn(string token, string tagName)
        {
            if (!AuthenticationService.IsAuthenticated(token)) return false;
            Processing.AddTagScan((InputTag)TagRepository.Tags[tagName]);
            return TagService.TurnScanOn(tagName);
        }
    }
}
