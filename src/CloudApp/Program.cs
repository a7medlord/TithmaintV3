using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CloudApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
             .UseIISIntegration()
                .UseKestrel()
                .UseUrls("http://192.168.1.6:5002")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
