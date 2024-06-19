using System.Runtime.Serialization;
using System.Xml.Linq;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure.Domain.Tag
{
    [DataContract]
    public class DigitalInputTag : InputTag
    {
        public override XElement GetXmlRepresentation()
        {
            XElement element = new XElement("DigitalInputTag");
            element.SetAttributeValue("TagName", TagName);
            element.SetAttributeValue("Description", Description);
            element.SetAttributeValue("Driver", DriverType);
            element.SetAttributeValue("IOAddress", IOAddress);
            element.SetAttributeValue("ScanTime", ScanTime);
            element.SetAttributeValue("Scan", Scan);
            return element;
        }
    }
}
