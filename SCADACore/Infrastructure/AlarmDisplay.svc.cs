using System;
using System.ServiceModel;
using SCADACore.Infrastructure.Contract;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure
{
    public class AlarmDisplay : IAlarmDisplay
    {
        private IAlarmDisplayCallback Callback { get; set; }

        public void InitAlarmDisplay()
        {
            Processing.OnValueRead += CheckTagAlarm;
            Callback = OperationContext.Current.GetCallbackChannel<IAlarmDisplayCallback>();
        }

        private void CheckTagAlarm(InputTag tag, double value, DateTime timestamp)
        {
            // TODO check alarm and invoke Callback if alarmed
        }
    }
}
