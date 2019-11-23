using System;
using System.Collections.Generic;
using System.Text;

namespace App.Queue.Contracts
{
    public interface IApplicationSettings
    {
        public string DefaultConnectionString { get; set; }
    }
}
