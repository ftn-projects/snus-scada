using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;
using System.Web;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure
{
    public static class Processing
    {
        public delegate void ValueReadDelegate(InputTag tag, double value);
        public static event ValueReadDelegate OnValueRead;

        private static readonly Dictionary<DriverType, IDriver> Drivers = new Dictionary<DriverType, IDriver>();
        private static readonly Dictionary<string, Thread> Scans = new Dictionary<string, Thread>();

        private const double ScanPrecision = 1e-5;

        public static void AddTagScan(InputTag tag)
        {
            Scans.Add(tag.TagName, new Thread(() =>
            {
                var scannedValue = 0.0;

                while (true)
                {
                    try
                    {
                        Thread.Sleep((int)tag.ScanTime);
                    }
                    catch (ThreadAbortException)
                    {
                        break;
                    }

                    scannedValue = ReadValue(tag, scannedValue);
                }
            }));
        }

        public static void RemoveTagScan(string tagName)
        {
            Scans[tagName].Abort();
            Scans.Remove(tagName);
        }
        
        public static double ReadValue(InputTag tag, double previousValue)
        {
            var newValue = Drivers[tag.DriverType].ReadValue(tag.IOAddress);

            if (Math.Abs(previousValue - newValue) < ScanPrecision)
                return previousValue;

            OnValueRead?.Invoke(tag, newValue);
            return newValue;
        }
    }
}