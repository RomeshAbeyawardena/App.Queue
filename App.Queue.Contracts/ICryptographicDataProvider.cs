using App.Queue.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Queue.Contracts
{
    public interface ICryptographicDataProvider
    {
        CryptographicData GetCryptographicData(byte[] key);
        byte[] GeneratePasswordDerivedKey(CryptographicData cryptographicData);
    }
}
