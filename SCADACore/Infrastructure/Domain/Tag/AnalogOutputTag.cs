using System.Runtime.Serialization;
using System.Xml.Linq;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure.Domain.Tag
{
    [DataContract]
    public class AnalogOutputTag : OutputTag
    {
        [DataMember]
        public double LowLimit { get; set; }
        [DataMember]
        public double HighLimit { get; set; }
        [DataMember]
        public string Units { get; set; }

        public override XElement GetXmlRepresentation()
        {
            XElement element = new XElement("AnalogOutputTag");
            element.SetAttributeValue("TagName", TagName);
            element.SetAttributeValue("Description", Description);
            element.SetAttributeValue("IOAddress", IOAddress);
            element.SetAttributeValue("InitialValue", InitialValue);
            element.SetAttributeValue("LowLimit", LowLimit);
            element.SetAttributeValue("HighLimit", HighLimit);
            element.SetAttributeValue("Units", Units);

            return element;
        }
    }
}