using System.Collections.Concurrent;
using SCADACore.Infrastructure.Contract;

namespace SCADACore.Infrastructure
{
    public class RtuDriver : IRtuDriver, IDriver
    {
        private static readonly ConcurrentDictionary<int, double> Memory = new ConcurrentDictionary<int, double>();

        public void InitRtuDriver()
        {
            // TODO public key handling
        }

        public void UpdateValue(int address, double value)
        {
            // TODO signature validation
            Memory[address] = value;
        }

        public double ReadValue(int address)
        {
            return Memory.TryGetValue(address, out var value) ? value : double.NaN;
        }
    }
}
