using System.IO;
using Owin;
namespace SimpleOwinWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("Hello");
            });

            // without Resposne
            /*app.Use(async (ctx, next) =>
            {
                var response = ctx.Environment["owin.ResponseBody"] as Stream;
                using (var writer = new StreamWriter(response))
                {
                    await writer.WriteAsync("Hello");
                }
            });*/
        }
    }
}