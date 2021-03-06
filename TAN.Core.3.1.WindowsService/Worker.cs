using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TAN.Core._3._1.WindowsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var googleUrl = ConfigurationManager.AppSettings.Get("GOOGLE_URL");

                if (!Directory.Exists("C:/Test"))
                    Directory.CreateDirectory("C:/Test");

                var sw = new StreamWriter($"C:/Test/LogFile_{DateTimeOffset.Now.ToString("yyyyMMddhhmm")}.txt", true);
                sw.WriteLine($"Worker running at: {DateTimeOffset.Now.ToString("yyyy/MM/dd hh:mm:ss")} google url: {googleUrl}");
                sw.Flush();
                sw.Close();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}