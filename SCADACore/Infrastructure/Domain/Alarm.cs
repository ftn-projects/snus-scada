using SCADACore.Infrastructure.Domain.Enumeration;
using System.Runtime.Serialization;

namespace SCADACore.Infrastructure.Domain
{
    [DataContract]
    public class Alarm
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Priority Priority { get; set; }

        [DataMember]
        public AlarmType AlarmType { get; set; }

        [DataMember]
        public double LimitValue { get; set; }

        [DataMember]
        public string Units { get; set; }
    }
}