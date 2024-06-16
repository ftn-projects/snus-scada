using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SCADACore.Infrastructure.Domain
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
