using DatabaseManager.ServiceReference;
using Infrastructure.Service.Utils;
using System;

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
            TagManagerClient tagManagerClient = new TagManagerClient();
            DigitalInputTag tag = new DigitalInputTag();

            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.DriverType = InputUtils.ReadOption(new DriverType[] { DriverType.Simulation, DriverType.Realtime }, "Select driver type"); 
            tag.IOAddress = InputUtils.ReadInt("I/O Address:", 0, 120);
            tag.Scan = InputUtils.ReadBool("Should scan be enabled?");
            tag.ScanTime = InputUtils.ReadDouble("Scan time:", 0);
            tagManagerClient.AddDigitalInputTag(Token, tag);
        }

        public void AddDigitalOutput()
        {
            TagManagerClient tagManagerClient = new TagManagerClient();
            DigitalOutputTag tag = new DigitalOutputTag();

            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.IOAddress = InputUtils.ReadInt("I/O Address:", 0, 120);
            tag.InitialValue = InputUtils.ReadDouble("Initial Value:");

        }

        public void AddAnalogInput()
        {

            TagManagerClient tagManagerClient = new TagManagerClient();
            AnalogInputTag tag = new AnalogInputTag();
            
            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.DriverType = InputUtils.ReadOption(new DriverType[] { DriverType.Simulation, DriverType.Realtime }, "Select driver type"); 
            tag.IOAddress = InputUtils.ReadInt("I/O Address:", 0, 120);
            tag.Scan = InputUtils.ReadBool("Should scan be enabled?");
            tag.ScanTime = InputUtils.ReadDouble("Scan time:", 0);
            tag.HighLimit = InputUtils.ReadDouble("High Limit value:");
            tag.LowLimit = InputUtils.ReadDouble("Low Limit value:", upperBound: tag.HighLimit);
            tag.Units = InputUtils.ReadStringNotEmpty("Units:");
            tagManagerClient.AddAnalogInputTag(Token, tag);
        }

        public void AddAnalogOutput()
        {
            TagManagerClient tagManagerClient = new TagManagerClient();
            AnalogOutputTag tag = new AnalogOutputTag();

            tag.TagName = InputUtils.ReadStringNotEmpty("Enter tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.IOAddress = InputUtils.ReadInt("I/O Address:", 0, 120);
            tag.InitialValue = InputUtils.ReadDouble("Initial value:");
            tag.HighLimit = InputUtils.ReadDouble("High Limit value:");
            tag.LowLimit = InputUtils.ReadDouble("Low Limit value:", upperBound: tag.HighLimit);
            tag.Units = InputUtils.ReadStringNotEmpty("Units:");

            tagManagerClient.AddAnalogOutputTag(Token, tag);
        }

        public void RemoveTag()
        {
            string tagname = InputUtils.ReadStringNotEmpty("Enter tag name:");
            TagManagerClient tagManagerClient = new TagManagerClient();
            if (tagManagerClient.RemoveTag(Token, tagname)) { Console.WriteLine("Tag removed"); return; };
            Console.WriteLine("Tag was not removed");
        }
        public void ListAllTags()
        {

            TagManagerClient tagManagerClient = new TagManagerClient();
            TagsState tagsState = tagManagerClient.GetTagsState(Token);

            Console.WriteLine("Anlog Input Tags\n");
            foreach(var tag in tagsState.AnalogInputTags)
            {
                Console.WriteLine($"{tag.TagName} | {tag.Description} | {tag.DriverType} | {tag.Scan} | {tag.ScanTime} | {tag.IOAddress} | {tag.LowLimit} | {tag.HighLimit} | {tag.Units}");
            }
        }
    }
}
