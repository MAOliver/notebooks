using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Example.API;
using Microsoft.Owin.Hosting;
using Serilog;

namespace Example.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.LiterateConsole().CreateLogger();

                Log.Logger.Information("Starting up application.");
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                Log.Logger.Information("Testing endpoint.");

                var response = client.GetAsync(baseAddress + "api/Examples").Result;
                Log.Logger.Information($"status code: {response.StatusCode}");
                Log.Logger.Information($"result: {response.Content.ReadAsStringAsync().Result}");
                Console.WriteLine("Press enter to stop the app...");
                Console.ReadLine();
            }
        }
    }
}
