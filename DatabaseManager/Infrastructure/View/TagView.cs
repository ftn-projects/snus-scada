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
            if (tagManagerClient.AddDigitalInputTag(Token, tag)) { Console.WriteLine("Digital ouput tag added successfully"); return; }
            Console.WriteLine("Operation failed");
        }

        public void AddDigitalOutput()
        {
            TagManagerClient tagManagerClient = new TagManagerClient();
            DigitalOutputTag tag = new DigitalOutputTag();

            tag.TagName = InputUtils.ReadStringNotEmpty("Enter Tag name:");
            tag.Description = InputUtils.ReadStringNotEmpty("Description:");
            tag.IOAddress = InputUtils.ReadInt("I/O Address:", 0, 120);
            tag.InitialValue = InputUtils.ReadDouble("Initial Value:");
            if (tagManagerClient.AddDigitalOutputTag(Token, tag)) { Console.WriteLine("Digital output tag added successfully"); return; }
            Console.WriteLine("Operation failed");
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
            if (tagManagerClient.AddAnalogInputTag(Token, tag)) { Console.WriteLine("Anlog input tag added successfully"); return; };
            Console.WriteLine("Operation failed");
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
            if(tagManagerClient.AddAnalogOutputTag(Token, tag)) { Console.WriteLine("Analog output tag added successfully"); return; }
            Console.WriteLine("Operation failed");
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
            ListDigitalInput(tagsState.DigitalInputTags);
            ListDigitalOutput(tagsState.DigitalOutputTags);
            ListAnalogOutput(tagsState.AnalogOutputTags);
            ListAnalogInput(tagsState.AnalogInputTags);
           
        }

        private void ListAnalogInput(AnalogInputTag[] tags)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Analog input tags");
            Console.WriteLine("===================================");
            foreach(var tag in tags)
            {
                Console.WriteLine($"\nTag name: {tag.TagName}");
                Console.WriteLine($"Description: {tag.Description}");
                Console.WriteLine($"I/O Address: {tag.IOAddress}");
                Console.WriteLine($"Is scan on: {tag.Scan}");
                Console.WriteLine($"Scan time: {tag.ScanTime}");
                Console.WriteLine($"Units: {tag.Units}");
                Console.WriteLine($"Low limit: {tag.LowLimit}");
                Console.WriteLine($"High limit: {tag.HighLimit}");
                Console.WriteLine($"Driver type: {tag.DriverType}");
            }
            Console.WriteLine("===================================\n\n");
        }

        private void ListAnalogOutput(AnalogOutputTag[] tags)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Analog input tags");
            Console.WriteLine("===================================");
            foreach(var tag in tags)
            {
                Console.WriteLine($"\nTag name: {tag.TagName}");
                Console.WriteLine($"Description: {tag.Description}");
                Console.WriteLine($"I/O Address: {tag.IOAddress}");
                Console.WriteLine($"Units: {tag.Units}");
                Console.WriteLine($"Low limit: {tag.LowLimit}");
                Console.WriteLine($"High limit: {tag.HighLimit}");
                Console.WriteLine($"Initial value: {tag.InitialValue}");
            }
            Console.WriteLine("===================================\n\n");
        }

        private void ListDigitalInput(DigitalInputTag[] tags)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Analog input tags");
            Console.WriteLine("===================================");
            foreach(var tag in tags)
            {
                Console.WriteLine($"\nTag name: {tag.TagName}");
                Console.WriteLine($"Description: {tag.Description}");
                Console.WriteLine($"I/O Address: {tag.IOAddress}");
                Console.WriteLine($"Is scan on: {tag.Scan}");
                Console.WriteLine($"Scan time: {tag.ScanTime}");
                Console.WriteLine($"Driver type: {tag.DriverType}");
            }

            Console.WriteLine("===================================\n\n");
        }

        private void ListDigitalOutput(DigitalOutputTag[] tags)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Analog input tags");
            Console.WriteLine("===================================");
            foreach(var tag in tags)
            {
                Console.WriteLine($"\nTag name: {tag.TagName}");
                Console.WriteLine($"Description: {tag.Description}");
                Console.WriteLine($"I/O Address: {tag.IOAddress}");
                Console.WriteLine($"Initial value: {tag.IOAddress}");
            }
            Console.WriteLine("===================================\n\n");
        }
    }
}
