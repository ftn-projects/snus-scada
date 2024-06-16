using SCADACore.Infrastructure.Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADACore.Infrastructure.Domain.Tag.Abstraction
{
    [DataContract]
    public abstract class InputTag : Tag
    {
        [DataMember]
        public double ScanTime { get; set; }
        [DataMember]
        public bool Scan { get; set; }
        [DataMember]
        public DriverType DriverType { get; set; }
    }
}