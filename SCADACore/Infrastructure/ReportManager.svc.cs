using SCADACore.Infrastructure.Contract;
using System.Collections.Generic;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Enumeration;
using System;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Repository;

namespace SCADACore.Infrastructure
{
    public class ReportManager : IReportManager
    {
        
        public List<AlarmInvocation> GetAlarmsByPriority(Priority priority)
        {
            return AlarmInvocationRepository.GetAlarmsByPriority(priority);
        }

        public List<AlarmInvocation> GetAlarmsInPeriod(DateTime start, DateTime end)
        {
            return AlarmInvocationRepository.GetAlarmsInPeriod(start, end);
        }

        public List<InputTagValue> GetAnalogInputTagValues()
        {
            return TagValueRepository.GetValuesByTagType(nameof(AnalogInputTag));
        }

        public List<InputTagValue> GetDigitalInputTagValues()
        {
            return TagValueRepository.GetValuesByTagType(nameof(DigitalInputTag));
        }

        public List<InputTagValue> GetInputTagValuesByPeriod(DateTime start, DateTime end)
        {
            return TagValueRepository.GetValuesInPeriod(start, end);   
        }

        public List<InputTagValue> GetInputTagValuesByTagName(string tagName)
        {
            return TagValueRepository.GetValuesByTagName(tagName);
        }
    }
}
