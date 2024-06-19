using System;
using ReportManager.ServiceReference;

namespace ReportManager
{
    internal class Program
    {
        private static ReportManagerClient _client;

        public static void Main()
        { 
            _client = new ReportManagerClient();

            string option;
            do
            {
                PrintMenu();
                option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        AlarmsByPriority();
                        break;
                    case "2":
                        AlarmsInPeriod();
                        break;
                    case "3":
                        AnalogInputTagValues();
                        break;
                    case "4":
                        DigitalInputTagValues();
                        break;
                    case "5":
                        InputTagValuesByPeriod();
                        break;
                    case "6":
                        InputTagValuesByTagName();
                        break;
                }
            } while (!string.Equals(option, "q", StringComparison.OrdinalIgnoreCase));
        }

        private static void PrintMenu()
        {
            Console.WriteLine("[1] Get alarms by priority");
            Console.WriteLine("[2] Get alarms in period");
            Console.WriteLine("[3] Get analog input tag values");
            Console.WriteLine("[4] Get digital input tag values");
            Console.WriteLine("[5] Get input tag values by period");
            Console.WriteLine("[6] Get input tag values by tag name");
            Console.WriteLine("[q] Quit");
        }

        private static void AlarmsByPriority()
        {
            var priority = InputUtils.ReadOption(new[] { Priority.Low, Priority.Medium, Priority.High });

            var results = _client.GetAlarmsByPriority(priority);
            PrintResults(results);
        }

        private static void AlarmsInPeriod()
        {
            var start = InputUtils.ReadDate("Start date: ");
            var end = InputUtils.ReadDate("End date: ", start);

            var results = _client.GetAlarmsInPeriod(start, end);
            PrintResults(results);
        }

        private static void AnalogInputTagValues()
        {
            var results = _client.GetAnalogInputTagValues();
            PrintResults(results);
        }

        private static void DigitalInputTagValues()
        {
            var results = _client.GetDigitalInputTagValues();
            PrintResults(results);
        }

        private static void InputTagValuesByPeriod()
        {
            var start = InputUtils.ReadDate("Start date: ");
            var end = InputUtils.ReadDate("End date: ", start);

            var results = _client.GetInputTagValuesByPeriod(start, end);
            PrintResults(results);
        }

        private static void InputTagValuesByTagName()
        {
            var tagName = InputUtils.ReadStringNotEmpty("Tag name: ");

            var results = _client.GetInputTagValuesByTagName(tagName);
            PrintResults(results);
        }

        private static void PrintResults<T>(T[] items)
        {
            Console.WriteLine("\n---------------Results---------------");
            Array.ForEach(items, ToString);
            Console.WriteLine("--------------------------------------\n");
        }

        private static void ToString<T>(T item)
        {
            switch (item)
            {
                case AlarmInvocation a:
                    var delta = (a.LimitDeltaValue > 0 ? "+" : "") + $"{a.LimitDeltaValue}";
                    Console.WriteLine($"[{a.Timestamp}] {a.TagName} {a.Name} {a.Limit + a.LimitDeltaValue} ({delta})");
                    break;
                case InputTagValue t:
                    Console.WriteLine($"[{t.Timestamp}] {t.TagName} {t.InputTagType} {t.DriverType} {t.Value}");
                    break;
                default:
                    Console.WriteLine(item.ToString());
                    break;
            }
        }
    }
}
