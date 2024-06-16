using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Linq;

namespace SCADACore.Infrastructure.Domain.Tag.Abstraction
{
    [DataContract]
    public abstract class Tag : ISerializableXml
    {
        [DataMember]
        public string TagName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int IOAddress { get; set; }

        public abstract XElement GetXmlRepresentation();
    }
}