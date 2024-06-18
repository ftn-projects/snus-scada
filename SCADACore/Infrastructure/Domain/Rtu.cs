using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADACore.Infrastructure.Domain
{
    [DataContract]
    public class Rtu
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int IOAddress { get; set; }
        [DataMember]
        public double LowestValue { get; set; }
        [DataMember]
        public double HighestValue { get; set; }
    }
}