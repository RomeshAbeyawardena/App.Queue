﻿using App.Queue.Contracts;
using Microsoft.Extensions.Configuration;
using System;

namespace App.Queue.Shared
{
    public class DefaultApplicationSettings : IApplicationSettings
    {
        public DefaultApplicationSettings(IConfiguration configuration)
        {
            DefaultConnectionString = configuration.GetConnectionString("default");
        }
        public string DefaultConnectionString { get; set; }
    }
}