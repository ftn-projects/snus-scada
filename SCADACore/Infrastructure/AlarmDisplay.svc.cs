using System;
using System.ServiceModel;
using SCADACore.Infrastructure.Contract;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using SCADACore.Infrastructure.Repository;
using SCADACore.Infrastructure.Utils;

namespace SCADACore.Infrastructure
{
    public class AlarmDisplay : IAlarmDisplay
    {
        private delegate void AlarmInvokedDelegate(AlarmInvocation alarm);
        private static event AlarmInvokedDelegate OnAlarmInvoked;

        static AlarmDisplay()
        {
            OnAlarmInvoked += AlarmInvocationRepository.Add;
            OnAlarmInvoked += AlarmInvocationLogger.Log;
        }

        
        private IAlarmDisplayCallback Callback { get; set; }

        public void InitAlarmDisplay()
        {
            Processing.OnValueRead += CheckTagAlarm;
            Callback = OperationContext.Current.GetCallbackChannel<IAlarmDisplayCallback>();
            OnAlarmInvoked += (alarm) =>
                Callback.OnAlarmInvoked(alarm);
        }

        private static void CheckTagAlarm(InputTag tag, double value, DateTime timestamp)
        {
            if (!(tag is AnalogInputTag analogTag)) 
                return;

            analogTag.Alarms.ForEach(a =>
            {
                double delta;

                if (a.AlarmType == AlarmType.Low)
                    delta = value < a.Limit ? value - a.Limit : 0.0;
                else
                    delta = value > a.Limit ? value - a.Limit : 0.0;

                if (delta == 0.0)
                    return;

                var invocation = new AlarmInvocation(a.Name, analogTag.TagName, a.Limit, delta, a.Units, timestamp, a.Priority);
                for (var _ = 0; _ < (int) a.Priority; _++)
                    OnAlarmInvoked?.Invoke(invocation);
            });
        }
    }
}
