using System;
using System.Linq;

namespace DatabaseManager.Infrastructure.Service
{
    public static class InputUtils
    {

        public static string ReadStringNotEmpty(string message = "")
        {
            while(true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) ) return input;
                Console.WriteLine("Input must not be empty");
            }
        }

        public static int ReadInt(string message = "", int lowerBound = int.MinValue, int upperBound = int.MaxValue)
        {
            while(true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                int number;
                if(int.TryParse(input, out number))
                {
                    if(number >= lowerBound && number <= upperBound) return number;
                }
                Console.WriteLine($"Input must be numeric, between {lowerBound} and {upperBound}");
            }
        }

        public static double ReadDouble(string message = "", double lowerBound = double.MinValue, double upperBound = double.MaxValue)
        {
            while(true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                double number;
                if(double.TryParse(input, out number))
                {
                    if (number >= lowerBound && number <= upperBound) return number;
                }
                Console.WriteLine($"Input must be numeric (float), between {lowerBound} and {upperBound}");
            }
        }

        public static bool ReadBool(string message = "")
        {
            while (true)
            {
                Console.WriteLine(message + " " + "[y/n]");
                string input = Console.ReadLine();
                if (input.Equals("y", StringComparison.OrdinalIgnoreCase)) return true;
                else if(input.Equals("n", StringComparison.OrdinalIgnoreCase) ) return false;
                Console.WriteLine("Invalid input, please type either Y or N character and press enter");
            }
        }
        
        public static T ReadOption<T>(T[] options,string message = "")
        {
            while (true)
            {
                Console.WriteLine(message);
                for(int i = 0; i < options.Count(); i++)
                {
                    Console.WriteLine($"[{i}] {options[i]}");
                }
                int option = ReadInt("",0,options.Count()-1);
                return options[option];
            }
        }
    }
}