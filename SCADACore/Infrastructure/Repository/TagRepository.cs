using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SCADACore.Infrastructure.Repository
{
    public class TagRepository
    {
        private static readonly string DATA_URL = "C:\\Fakultet\\Semestar 6\\Softver Nadzorno-Upravljackih Sistema\\projekat\\snus-scada\\SCADACore\\App_Data\\scadaConfig.xml"; 

        public List<AnalogInputTag> AnalogInputTags { get; set; } = new List<AnalogInputTag>();
        public List<AnalogOutputTag> AnalogOutputTags { get; set; } = new List<AnalogOutputTag>();
        public List<DigitalInputTag> DigitalInputTags { get; set; } = new List<DigitalInputTag>();
        public List<DigitalOutputTag> DigitalOutputTags { get; set; } = new List<DigitalOutputTag>();

        public TagRepository() 
        {
           LoadAnalogInputTags();
           LoadAnalogOutputTags();
           LoadDigitalInputTags();
           LoadDigitalOutputTags();
        }

        private void LoadDigitalOutputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> digitalgOutputTagsXML = xmlData.Descendants("DigitalOutputTag");
            if (digitalgOutputTagsXML.Count() < 1) return;
            DigitalOutputTags = (from tag in digitalgOutputTagsXML
                                 select new DigitalOutputTag()
                                 {
                                     TagName = tag.Attribute("TagName").Value,
                                     Description = tag.Attribute("Description").Value,  
                                     IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                     InitialValue = Convert.ToDouble(tag.Attribute("InitialValue").Value)
                                 }).ToList();
        }

        private void LoadDigitalInputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> digitalInputTagsXML = xmlData.Descendants("DigitalInputTag");
            if (digitalInputTagsXML.Count() < 1) return;
            DigitalInputTags = (from tag in digitalInputTagsXML
                                select new DigitalInputTag()
                                {
                                    TagName = tag.Attribute("TagName").Value,
                                    Description = tag.Attribute("Description").Value,
                                    IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                    DriverType = EnumUtils.ParseEnum<DriverType>(tag.Attribute("Driver").Value),
                                    Scan = Convert.ToBoolean(tag.Attribute("Scan").Value),
                                    ScanTime = Convert.ToDouble(tag.Attribute("ScanTime").Value)
                                }).ToList();
        }

        private void LoadAnalogOutputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> analogOutputTagsXML = xmlData.Descendants("AnalogOutputTag");
            if (analogOutputTagsXML.Count() < 1) return;
            AnalogOutputTags = (from tag in  analogOutputTagsXML
                               select new AnalogOutputTag()
                               {
                                   TagName = tag.Attribute("TagName").Value,
                                   Description = tag.Attribute("Description").Value,
                                   IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                   HighLimit = Convert.ToDouble(tag.Attribute("HighLimit").Value),
                                   LowLimit = Convert.ToDouble(tag.Attribute("LowLimit").Value),
                                   InitialValue = Convert.ToDouble(tag.Attribute("InitialValue").Value),
                                   Units = tag.Attribute("Units").Value
                               }).ToList();
        }

        private void LoadAnalogInputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> analogInputTagsXML = xmlData.Descendants("AnalogInputTag");
            if (analogInputTagsXML.Count() < 1) return;
            AnalogInputTags = (from tag in analogInputTagsXML
                               select new AnalogInputTag()
                               {
                                   TagName = tag.Attribute("TagName").Value,
                                   Description = tag.Attribute("Description").Value,
                                   DriverType = EnumUtils.ParseEnum<DriverType>(tag.Attribute("Driver").Value),
                                   IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                   ScanTime = Convert.ToDouble(tag.Attribute("ScanTime").Value),
                                   Scan = Convert.ToBoolean(tag.Attribute("Scan").Value),
                                   LowLimit = Convert.ToDouble(tag.Attribute("LowLimit").Value),
                                   HighLimit = Convert.ToDouble(tag.Attribute("HighLimit").Value),
                                   Units = tag.Attribute("Units").Value,
                                   Alarms = GetAlarmsFromXMLData(tag)
                               }).ToList();
        }
        
        private List<Alarm> GetAlarmsFromXMLData(XElement xmlData)
        {
            IEnumerable<XElement> alarmsXML = xmlData.Descendants("Alarm");
            if (alarmsXML.Count() < 1) return new List<Alarm>();
            return (from alarm in alarmsXML
                     select new Alarm()
                     {
                         AlarmType = EnumUtils.ParseEnum<AlarmType>(alarm.Attribute("AlarmType").Value),
                         Priority = EnumUtils.ParseEnum<Priority>(alarm.Attribute("Priority").Value),
                         Units = alarm.Attribute("Units").Value,
                         LimitValue = Convert.ToDouble(alarm.Attribute("LimitValue").Value)
                     }).ToList();
        }
        
        public bool SaveChanges()
        {
            XDocument xmlDocument = new XDocument();
            XElement analogInputTagsXML = GetAnalogInputTagsXML();
            XElement analogOutputTagsXML = GetAnalogOutputTagsXML();
            XElement digitalInputTagsXML = GetDigitalInputTagsXML();
            XElement digitalOutputTagsXML = GetDigitalOuputTagsXML();
            xmlDocument.Add(analogInputTagsXML);
            xmlDocument.Add(digitalInputTagsXML);
            xmlDocument.Add(analogOutputTagsXML);
            xmlDocument.Add(digitalOutputTagsXML);
            xmlDocument.Save(DATA_URL);
            return true;
        }

        private XElement GetAnalogInputTagsXML()
        {
            XElement analogInputTagsXML = new XElement("AnalogInputTags");
            foreach (var tag in AnalogInputTags)
            {
                XElement element = new XElement("AnalogInputTag");
                element.SetAttributeValue("TagName", tag.TagName);
                element.SetAttributeValue("Description", tag.Description);
                element.SetAttributeValue("Driver", tag.DriverType);
                element.SetAttributeValue("IOAddress", tag.IOAddress);
                element.SetAttributeValue("ScanTime", tag.ScanTime);
                element.SetAttributeValue("Scan", tag.Scan);
                element.SetAttributeValue("LowLimit", tag.LowLimit);
                element.SetAttributeValue("HighLimit", tag.HighLimit);
                element.SetAttributeValue("Units", tag.Units);

                XElement alarmsXML = new XElement("Alarms");
                foreach (var alarm in tag.Alarms)
                {
                    XElement alarmXML = new XElement("Alarm");
                    alarmXML.SetAttributeValue("AlarmType", alarm.AlarmType);
                    alarmXML.SetAttributeValue("Units", alarm.Units);
                    alarmXML.SetAttributeValue("LimitValue", alarm.LimitValue);
                    alarmXML.SetAttributeValue("Priority", alarm.Priority);
                    alarmsXML.Add(alarmXML);
                }
                element.Add(alarmsXML);
                analogInputTagsXML.Add(element);
            }

            return analogInputTagsXML;
        }

        private XElement GetAnalogOutputTagsXML()
        {
            XElement analogOutputTagsXML = new XElement("AnalogOutputTags");
            foreach (var tag in AnalogOutputTags)
            {
                XElement element = new XElement("AnalogOutputTag");
                element.SetAttributeValue("TagName", tag.TagName);
                element.SetAttributeValue("Description", tag.Description);
                element.SetAttributeValue("IOAddress", tag.IOAddress);
                element.SetAttributeValue("InitialValue", tag.InitialValue);
                element.SetAttributeValue("LowLimit", tag.LowLimit);
                element.SetAttributeValue("HighLimit", tag.HighLimit);
                element.SetAttributeValue("Units", tag.Units);
                analogOutputTagsXML.Add(element);
            }

            return analogOutputTagsXML;
        }

        private XElement GetDigitalInputTagsXML()
        {
            XElement digitalInputTagsXML = new XElement("DigitalInputTags");
            foreach (var tag in DigitalInputTags)
            {
                XElement element = new XElement("DigitalInputTag");
                element.SetAttributeValue("TagName", tag.TagName);
                element.SetAttributeValue("Description", tag.Description);
                element.SetAttributeValue("Driver", tag.DriverType);
                element.SetAttributeValue("IOAddress", tag.IOAddress);
                element.SetAttributeValue("ScanTime", tag.ScanTime);
                element.SetAttributeValue("Scan", tag.Scan);
                digitalInputTagsXML.Add(element);
            }

            return digitalInputTagsXML;
        }

        private XElement GetDigitalOuputTagsXML()
        {
            XElement digitalOutputTagsXML = new XElement("DigitalOutputTags");
            foreach (var tag in DigitalOutputTags)
            {
                XElement element = new XElement("DigitalOutputTag");
                element.SetAttributeValue("TagName", tag.TagName);
                element.SetAttributeValue("Description", tag.Description);
                element.SetAttributeValue("IOAddress", tag.IOAddress);
                element.SetAttributeValue("InitialValue", tag.InitialValue);
                digitalOutputTagsXML.Add(element);
            }

            return digitalOutputTagsXML;
        }
    }
}