using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SCADACore.Infrastructure.Domain.Tag.Abstraction
{
    [DataContract]
    public abstract class OutputTag : Tag
    {
        [DataMember]
        public double InitialValue { get; set; }
    }
}