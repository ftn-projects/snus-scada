using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADACore.Infrastructure.Domain
{
    [DataContract]
    public class AnalogInputTag : InputTag
    {
        [DataMember]
        public double LowLimit { get; set; }
        [DataMember]
        public double HighLimit { get; set; }
        [DataMember]
        public string Units { get; set; }
        [DataMember]
        public List<Alarm> Alarms { get; set; } = new List<Alarm>();

        public AnalogInputTag() { }
    }
}