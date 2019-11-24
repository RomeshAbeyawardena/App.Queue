using App.Queue.Contracts;
using App.Queue.Domains;
using Shared.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace App.Queue.Services.Providers
{
    public class CryptographicDataProvider : ICryptographicDataProvider
    {
        private readonly IApplicationSettings applicationSettings;
        private readonly IEncodingProvider encodingProvider;
        private readonly ICryptographicProvider cryptographicProvider;

        public CryptographicData GetCryptographicData(byte[] key)
        {
            var defaultEncoding = encodingProvider.GetEncoding(encodingProvider.Encodings, applicationSettings.DefaultEncoding);
            var cryptographicData = cryptographicProvider.ExtractDigestValues(defaultEncoding, applicationSettings.Digest, Constants.DigestSeparator).ToArray();

            return new CryptographicData { 
                Password = cryptographicData[0],
                Salt = cryptographicData[1],
                Key = key
            };
        }

        public byte[] GeneratePasswordDerivedKey(CryptographicData cryptographicData)
        {
            return cryptographicProvider.GenerateKey(cryptographicData.Salt, cryptographicData.Password, applicationSettings.Iterations, 32, HashAlgorithmName.SHA512);
        }

        public CryptographicDataProvider(IApplicationSettings applicationSettings, IEncodingProvider encodingProvider, ICryptographicProvider cryptographicProvider)
        {
            this.applicationSettings = applicationSettings;
            this.encodingProvider = encodingProvider;
            this.cryptographicProvider = cryptographicProvider;
        }
    }
}
