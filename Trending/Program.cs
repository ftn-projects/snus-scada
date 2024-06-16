using System;
using System.ServiceModel;
using Trending.ServiceReference;

namespace Trending
{
    internal class Program
    {
        public class TrendingCallback : ITrendingCallback
        {
            public void OnTrendingTagPrint(InputTagValue value)
            {
                Console.WriteLine($"Tag Name: {value.TagName}");
                Console.WriteLine($"Value: {value.Value}");
                Console.WriteLine($"Driver type: {value.DriverType}");
                Console.WriteLine($"Time: {value.Timestamp}");
                Console.WriteLine("--------------------------------------");
            }
        }

        static void Main(string[] args)
        {
            var ic = new InstanceContext(new TrendingCallback());
            var client = new TrendingClient(ic);

            Console.WriteLine("\n---------------Trending---------------");

            client.InitTrending();
            Console.ReadKey();
        }
    }
}
