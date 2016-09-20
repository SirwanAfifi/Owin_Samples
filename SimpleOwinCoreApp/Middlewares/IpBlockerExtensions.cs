using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace SimpleOwinCoreApp.Middlewares
{
    public static class IpBlockerExtensions
    {
        public static IApplicationBuilder UseIpBlocker(this IApplicationBuilder builder, IConfigurationRoot configuration, IpBlockerOptions options = null)
        {
            return builder.UseMiddleware<IpBlockerMiddleware>(options ?? new IpBlockerOptions
            {
                Ips = configuration.GetSection("block_list").GetChildren().Select(p => p.Value).ToArray()
            });
        }
    }
}