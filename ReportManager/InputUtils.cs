using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace DatabaseManager.Infrastructure.Service
{
    public static class InputUtils
    {
        private const string DatePattern = "yyyy/MM/dd HH:mm";

        public static string ReadStringNotEmpty(string message = "")
        {
            while(true)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) ) return input;
                Console.WriteLine("Input must not be empty");
            }
        }

        public static int ReadInt(string message = "", int lowerBound = int.MinValue, int upperBound = int.MaxValue)
        {
            while(true)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                if(int.TryParse(input, out var number))
                {
                    if(number >= lowerBound && number <= upperBound) return number;
                }
                Console.WriteLine($"Input must be numeric, between {lowerBound} and {upperBound}");
            }
        }

        public static DateTime ReadDate(string message = "", DateTime? before = null)
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                if (DateTime.TryParseExact(input, DatePattern, CultureInfo.InvariantCulture, 
                           DateTimeStyles.None, out var date))
                {
                    if (date.CompareTo(before) > 0)
                        return date;
                    Console.WriteLine($"Date must be after {before}");
                }
                else
                {
                    Console.WriteLine("Date must be of format: dd/MM/yyyy hh:MM");
                }
            }
        }
        
        public static T ReadOption<T>(T[] options, string message = "")
        {
            while (true)
            {
                Console.Write(message);
                for(var i = 0; i < options.Count(); i++)
                {
                    Console.WriteLine($"[{i}] {options[i]}");
                }
                var option = ReadInt("Option: ",0,options.Count()-1);
                return options[option];
            }
        }
    }
}