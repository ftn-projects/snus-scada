using Infrastructure.Utils;
using RealTimeUnit.Infrastructure.Utils;
using RealTimeUnit.ServiceReference;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace RealTimeUnit.Infrastructure
{
    public class Application
    {
        private Mode _mode;
        private string _name;
        private int _ioAddress;
        private double _lowestValue;
        private double _highestValue;
        private CspParameters _csp;
        private RSACryptoServiceProvider _cryptoService;
        private RtuDriverClient _client;

        public Application() 
        {
        
            _csp = new CspParameters();
            _cryptoService = new RSACryptoServiceProvider(_csp);
            _client = new RtuDriverClient();
        }

        public void Start()
        {
            Init();
            if (_mode.Equals(Mode.AUTOMATIC)) StartAutomatic();
            else StartManual();
        }
        public void StartManual()
        {
            double input;
            while (true)
            {
                input = InputUtils.ReadDouble("Send Value: ", _lowestValue, _highestValue);
                byte[] signature = CryptoUtils.SignMessage(BitConverter.GetBytes(input), _cryptoService);
                _client.UpdateValue(_ioAddress, input, signature);
            }
        }
        public void StartAutomatic()
        {
            int inputTime = InputUtils.ReadInt("Seconds between data transfering:", lowerBound: 0);
            double input;
            Random rand = new Random();
            while (true)
            {
                Thread.Sleep(inputTime * 1000);
                input = rand.Next((int)_lowestValue, (int)_highestValue + 1);
                byte[] signature = CryptoUtils.SignMessage(BitConverter.GetBytes(input), _cryptoService);
                _client.UpdateValue(_ioAddress, input, signature);
            }

        }

        private void Init()
        {
            _mode = InputUtils.ReadOption<Mode>(new Mode[] { Mode.MANUAL, Mode.AUTOMATIC },"Select the input mode:");
            _name = InputUtils.ReadStringNotEmpty("RTU's unique name: ");
            _ioAddress = InputUtils.ReadInt("I/O Address: ", 0, 120);
            _lowestValue = InputUtils.ReadDouble("Lowest input: ");
            _highestValue = InputUtils.ReadDouble("Highest input: ", lowerBound: _lowestValue);
            _client.InitRtuDriver(CryptoUtils.GetPublicKeyForTransfer(_cryptoService));
        }

    }
}
