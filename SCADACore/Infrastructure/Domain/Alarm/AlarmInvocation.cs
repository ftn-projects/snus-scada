using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure.Domain.Alarm
{
    [DataContract]
    public class AlarmInvocation
    {
        [Key]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember] 
        public string TagName { get; set; }
        [DataMember]
        public double Limit { get; set; }
        [DataMember]
        public Priority Priority { get; set; }
        [DataMember]
        public double LimitDeltaValue { get; set; }  // (+3), (-5)...
        [DataMember] 
        public string Units { get; set; }
        [DataMember] 
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"[{Timestamp}] alarm: {Name}, tag: {TagName}, value: {Limit + LimitDeltaValue} " +
                   $"({(LimitDeltaValue > 0 ? "+" : "")}{LimitDeltaValue}) {Units}";
        }

        public AlarmInvocation(string name, string tagName, double limit, double limitDeltaValue, string units, DateTime timestamp, Priority priority)
        {
            Name = name;
            TagName = tagName;
            Limit = limit;
            LimitDeltaValue = limitDeltaValue;
            Units = units;
            Timestamp = timestamp;
            Priority = priority;
        }
    }
}