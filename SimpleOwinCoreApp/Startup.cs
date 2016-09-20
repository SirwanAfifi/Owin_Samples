using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleOwinCoreApp.Middlewares;

namespace SimpleOwinCoreApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { set; get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("blockedIps.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIpBlocker(Configuration);

            app.UseMiddleware<SimpleMiddleware>();
            
            // using Katana-based middlewares
            /*app.UseOwin(pipeline =>
            {
                pipeline(next => new MyKatanaBasedMiddleware(next).Invoke)
            });*/
        }
    }
}
