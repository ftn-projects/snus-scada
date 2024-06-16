using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Linq;

namespace SCADACore.Infrastructure.Domain
{
    [DataContract]
    public class AnalogInputTag : InputTag    {
        [DataMember]
        public double LowLimit { get; set; }
        [DataMember]
        public double HighLimit { get; set; }
        [DataMember]
        public string Units { get; set; }
        [DataMember]
        public List<Alarm> Alarms { get; set; } = new List<Alarm>();

        public AnalogInputTag() { }

        public override XElement GetXmlRepresentation()
        {
            XElement element = new XElement("AnalogInputTag");
            element.SetAttributeValue("TagName", TagName);
            element.SetAttributeValue("Description", Description);
            element.SetAttributeValue("Driver", DriverType);
            element.SetAttributeValue("IOAddress", IOAddress);
            element.SetAttributeValue("ScanTime", ScanTime);
            element.SetAttributeValue("Scan", Scan);
            element.SetAttributeValue("LowLimit", LowLimit);
            element.SetAttributeValue("HighLimit", HighLimit);
            element.SetAttributeValue("Units", Units);

            XElement alarmsXML = new XElement("Alarms");
            if (Alarms != null && Alarms.Count() > 0)
            {
                foreach (var alarm in Alarms)
                {
                    XElement alarmXML = new XElement("Alarm");
                    alarmXML.SetAttributeValue("AlarmType", alarm.AlarmType);
                    alarmXML.SetAttributeValue("Units", alarm.Units);
                    alarmXML.SetAttributeValue("LimitValue", alarm.LimitValue);
                    alarmXML.SetAttributeValue("Priority", alarm.Priority);
                    alarmsXML.Add(alarmXML);
                }
            }
            element.Add(alarmsXML);
            return element;
        }
    }
}