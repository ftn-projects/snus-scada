using System.Security.Cryptography;

namespace RealTimeUnit.Infrastructure.Utils
{
    public static class CryptoUtils
    {
        public static byte[] SignMessage(byte[] message, RSACryptoServiceProvider cryptoService)
        {
            using(SHA256 sha = SHA256Managed.Create())
            {
                var hashValue = sha.ComputeHash(message);

                var formatter = new RSAPKCS1SignatureFormatter(cryptoService);
                formatter.SetHashAlgorithm("SHA256");
                return formatter.CreateSignature(hashValue);
            }
        }

        public static string GetPublicKeyForTransfer(RSACryptoServiceProvider cryptoServiceProvider)
        {
            return cryptoServiceProvider.ToXmlString(false);
        }

    }

}
