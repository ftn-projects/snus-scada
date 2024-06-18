using System;
using System.Collections.Generic;
using System.Threading;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure
{
    public static class Processing
    {
        public delegate void ValueReadDelegate(InputTag tag, double value, DateTime timestamp);
        public static event ValueReadDelegate OnValueRead;

        private const double ScanPrecision = 1e-5;
        private static readonly Dictionary<string, Thread> Scans = new Dictionary<string, Thread>();
        private static readonly Dictionary<DriverType, IDriver> Drivers = new Dictionary<DriverType, IDriver>
        {
            { DriverType.Realtime, new RtuDriver() },
            { DriverType.Simulation, new SimulationDriver() }
        };

        static Processing()
        {
            // OnValueRead += logger;
        }

        public static void AddTagScan(InputTag tag)
        {
            Scans.Add(tag.TagName, new Thread(() =>
            {
                var scannedValue = double.NaN;

                while (true)
                {
                    try
                    {
                        Thread.Sleep((int)tag.ScanTime);
                    }
                    catch (ThreadInterruptedException)
                    {
                        break;
                    }

                    scannedValue = ReadValue(tag, scannedValue);
                }
            }));
        }

        public static void RemoveTagScan(string tagName)
        {
            Scans[tagName].Interrupt();
            Scans.Remove(tagName);
        }
        
        public static double ReadValue(InputTag tag, double previousValue)
        {
            if (!Drivers.ContainsKey(tag.DriverType)) 
                return previousValue;

            var newValue = Drivers[tag.DriverType].ReadValue(tag.IOAddress);

            if (double.IsNaN(newValue))
                return previousValue;
            if (!double.IsNaN(previousValue) && Math.Abs(previousValue - newValue) < ScanPrecision)
                return previousValue;

            OnValueRead?.Invoke(tag, newValue, DateTime.Now);
            return newValue;
        }
    }
}