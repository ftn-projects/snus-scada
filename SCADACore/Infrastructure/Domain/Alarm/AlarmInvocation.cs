using System;
using System.Runtime.Serialization;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure.Domain.Alarm
{
    [DataContract]
    public class AlarmInvocation
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember] 
        public AnalogInputTag Tag { get; set; }
        [DataMember]
        public double Limit { get; set; }
        [DataMember]
        public double LimitDeltaValue { get; set; }  // (+3), (-5)...
        [DataMember] 
        public string Units { get; set; }
        [DataMember] 
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"[{Timestamp}] alarm: {Name}, tag: {Tag.TagName}, value: {Limit + LimitDeltaValue} " +
                   $"({(LimitDeltaValue > 0 ? "+" : "")}{LimitDeltaValue}) {Units}";
        }

        public AlarmInvocation(string name, AnalogInputTag tag, double limit, double limitDeltaValue, string units, DateTime timestamp)
        {
            Name = name;
            Tag = tag;
            Limit = limit;
            LimitDeltaValue = limitDeltaValue;
            Units = units;
            Timestamp = timestamp;
        }
    }
}