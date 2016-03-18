using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup(typeof(Example.API.Startup))]

namespace Example.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = Log.Logger ?? new LoggerConfiguration().MinimumLevel.Debug().WriteTo.RollingFile(@"c:\logs\LawgicProductApi-{Date}.log").CreateLogger();

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
