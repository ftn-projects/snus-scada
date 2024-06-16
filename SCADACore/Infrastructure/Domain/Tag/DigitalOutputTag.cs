using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace SCADACore.Infrastructure.Domain
{
    [DataContract]
    public class DigitalOutputTag : OutputTag
    {
        public override XElement GetXmlRepresentation()
        {
            XElement element = new XElement("DigitalOutputTag");
            element.SetAttributeValue("TagName", TagName);
            element.SetAttributeValue("Description", Description);
            element.SetAttributeValue("IOAddress", IOAddress);
            element.SetAttributeValue("InitialValue", InitialValue);
            return element;
        }
    }
}