using App.Queue.Contracts;
using Microsoft.Extensions.Configuration;

namespace App.Queue.Shared
{
    public class DefaultApplicationSettings : IApplicationSettings
    {
        public DefaultApplicationSettings(IConfiguration configuration)
        {
            configuration.Bind(this);
            DefaultConnectionString = configuration.GetConnectionString("default");
        }
        public string DefaultConnectionString { get; set; }
        public string Digest { get; set; }
        public string DefaultEncoding { get; set; }
        public int Iterations { get; set; }
    }
}
