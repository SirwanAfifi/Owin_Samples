using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimpleOwinCoreApp.Middlewares
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            // قبل از فراخوانی میان‌افزار بعدی

            await ctx.Response.WriteAsync("Hello DNT!");

            await _next(ctx);

            // بعد از فراخوانی میان‌افزار بعدی
        }
    }
}