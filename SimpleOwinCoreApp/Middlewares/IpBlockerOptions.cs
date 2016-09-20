using System.Collections.Generic;

namespace SimpleOwinCoreApp.Middlewares
{
    public class IpBlockerOptions
    {
        public IpBlockerOptions()
        {
            Ips = new[] { "192.168.1.1" };
        }
        public IList<string> Ips { get; set; }
    }
}