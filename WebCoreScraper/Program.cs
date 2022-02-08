using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebCoreScraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var instance = Controllers.ScraperHomeController.GetInstance();
            var res = instance.GetScrapeMvsevm(default).Result;

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
