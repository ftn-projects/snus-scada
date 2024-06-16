using SCADACore.Infrastructure.Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADACore.Infrastructure.Domain
{
    [DataContract]
    public class Alarm
    {
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