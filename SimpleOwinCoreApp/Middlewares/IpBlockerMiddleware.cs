using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimpleOwinCoreApp.Middlewares
{
    public class IpBlockerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IpBlockerOptions _options;

        public IpBlockerMiddleware(RequestDelegate next, IpBlockerOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            var ipAddress = context.Request.Host.Host;
            if (IsBlockedIpAddress(ipAddress))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Forbidden : The server understood the request, but It is refusing to fulfill it.");
                return;
            }
            await _next.Invoke(context);
        }

        private bool IsBlockedIpAddress(string ipAddress)
        {
            return _options.Ips.Any(ip => ip == ipAddress);
        }
    }
}