using SCADACore.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Infrastructure.View
{
    public class TagView
    {
        private string Token { get; set; }   

        public TagView(string token) 
        {
            Token = token;
        }

        public void Init()
        {

            string option;
            do
            {
                PrintMenu();
                option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        AddDigitalInput();
                        break;
                    case "2":
                        AddDigitalOutput();
                        break;
                    case "3":
                        AddAnalogInput();
                        break;
                    case "4":
                        AddAnalogOutput();
                        break;
                    case "5":
                        RemoveTag();
                        break;
                    case "6":
                        ListAllTags();
                        break;
                    default:
                        break;
                }

            } while (!string.Equals(option, "q", StringComparison.OrdinalIgnoreCase));
        }

        public void PrintMenu()
        {
            Console.WriteLine("[1] Add digital input tag");
            Console.WriteLine("[2] Add digital output tag");
            Console.WriteLine("[3] Add analog input tag");
            Console.WriteLine("[4] Add analog output tag");
            Console.WriteLine("[5] Remove tag");
            Console.WriteLine("[6] List all tags");
            Console.WriteLine("[q] Back");
        }

        public void AddDigitalInput()
        {
            TagServiceReference.TagManagerClient tagManagerClient = new TagServiceReference.TagManagerClient();
            TagServiceReference.DigitalInputTag tag = new TagServiceReference.DigitalInputTag();

            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.DriverType = InputUtils.ReadOption(new TagServiceReference.DriverType[] { TagServiceReference.DriverType.Simulation, TagServiceReference.DriverType.Realtime }, "Select driver type"); 
            tag.IOAddress = InputUtils.ReadInt("I/O Address", 0, 120);
            tag.Scan = InputUtils.ReadBool("Should scan be enabled?");
            tag.ScanTime = InputUtils.ReadDouble("Scan time:", 0);
            tagManagerClient.AddDigitalInputTag(Token, tag);
        }

        public void AddDigitalOutput()
        {
            TagServiceReference.TagManagerClient tagManagerClient = new TagServiceReference.TagManagerClient();
            TagServiceReference.DigitalOutputTag tag = new TagServiceReference.DigitalOutputTag();

            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.IOAddress = InputUtils.ReadInt("I/O Address", 0, 120);
            tag.InitialValue = InputUtils.ReadDouble("Initial Value:");

        }

        public void AddAnalogInput()
        {

            TagServiceReference.TagManagerClient tagManagerClient = new TagServiceReference.TagManagerClient();
            TagServiceReference.AnalogInputTag tag = new TagServiceReference.AnalogInputTag();
            
            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.DriverType = InputUtils.ReadOption(new TagServiceReference.DriverType[] { TagServiceReference.DriverType.Simulation, TagServiceReference.DriverType.Realtime }, "Select driver type"); 
            tag.IOAddress = InputUtils.ReadInt("I/O Address", 0, 120);
            tag.Scan = InputUtils.ReadBool("Should scan be enabled?");
            tag.ScanTime = InputUtils.ReadDouble("Scan time:", 0);
            tag.HighLimit = InputUtils.ReadDouble("High Limit value:");
            tag.LowLimit = InputUtils.ReadDouble("Low Limit value:", upperBound: tag.HighLimit);
            tag.Units = InputUtils.ReadStringNotEmpty("Units:");
            tagManagerClient.AddAnalogInputTag(Token, tag);
        }

        public void AddAnalogOutput()
        {
            TagServiceReference.TagManagerClient tagManagerClient = new TagServiceReference.TagManagerClient();
            TagServiceReference.AnalogOutputTag tag = new TagServiceReference.AnalogOutputTag();

            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.IOAddress = InputUtils.ReadInt("I/O Address", 0, 120);
            tag.InitialValue = InputUtils.ReadDouble("Initial value:");
            tag.HighLimit = InputUtils.ReadDouble("High Limit value:");
            tag.LowLimit = InputUtils.ReadDouble("Low Limit value:", upperBound: tag.HighLimit);
            tag.Units = InputUtils.ReadStringNotEmpty("Units:");

            tagManagerClient.AddAnalogOutputTag(Token, tag);
        }

        public void RemoveTag() 
        {
        
        }
        public void ListAllTags()
        {

        }
    }
}
