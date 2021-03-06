using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace TAN.Core._3._1.WindowsService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGoogle(this IServiceCollection sercice, IConfiguration configuration)
        {
            var googleUrl = configuration["Google:Url"];

            ConfigurationManager.AppSettings.Set("GOOGLE_URL", googleUrl);

            return sercice;
        }
    }
}