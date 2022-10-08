using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuddanApplication.Application.Common.Interfaces
{
    public interface ISec
    {
        public string EncryptString(string text);
        public string DecryptString(string text);
        public byte[] Transform(byte[] input, ICryptoTransform CryptoTransform);
        public string privateKeySTR { get; }
        public string publicKeySTR { get; }
        public RSAParameters privateKey();
        public RSAParameters publicKey();
        public string EncryptByPrivateKey(string m);
        public string DecryptByPrivateKey(string c);
        public string EncryptByPublicKey(string m);
        public string DecryptByPublicKey(string c);
    }
}
