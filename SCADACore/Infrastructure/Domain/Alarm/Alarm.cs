using SCADACore.Infrastructure.Domain.Enumeration;
using System.Runtime.Serialization;

namespace SCADACore.Infrastructure.Domain.Alarm
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
        public double Limit { get; set; }

        [DataMember]
        public string Units { get; set; }
    }
}