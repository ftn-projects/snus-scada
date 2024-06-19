using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using DriverLibrary;
using SCADACore.Infrastructure.Contract;

namespace SCADACore.Infrastructure
{
    public class RtuDriver : IRtuDriver, IDriver
    {
        private static readonly ConcurrentDictionary<int, double> Memory = new ConcurrentDictionary<int, double>();
        private RSACryptoServiceProvider _cryptoServiceProvider;
        private CspParameters _csp;
        
        public void InitRtuDriver(string publicKey)
        {
            _csp = new CspParameters();
            _cryptoServiceProvider = new RSACryptoServiceProvider(_csp);
            _cryptoServiceProvider.FromXmlString(publicKey);
        }

        public void UpdateValue(int address, double value, byte[] signature)
        {

            // TODO signature validation
            if (!IsSignatureValid(value, signature)) return;
            
            Memory[address] = value;
        }

        public double ReadValue(int address)
        {
            return Memory.TryGetValue(address, out var value) ? value : double.NaN;
        }


        private bool IsSignatureValid(double data, byte[] signature)
        {
            using(SHA256 sha256 = SHA256Managed.Create()) 
            {
                var hashValue = sha256.ComputeHash(BitConverter.GetBytes(data));
                var deformatter = new RSAPKCS1SignatureDeformatter(_cryptoServiceProvider);
                deformatter.SetHashAlgorithm("SHA256");

                return deformatter.VerifySignature(hashValue, signature);

            }
        }
    }
}
