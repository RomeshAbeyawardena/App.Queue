using System;
using System.Collections.Generic;
using System.Text;

namespace App.Queue.Domains
{
    public class CryptographicData
    {
        public byte[] Key { get;set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
