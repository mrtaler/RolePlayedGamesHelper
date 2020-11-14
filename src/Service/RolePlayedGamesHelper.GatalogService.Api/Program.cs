using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace RolePlayedGamesHelper.GatalogService.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      var urls = "http://*:9015"; // KeyVaultBase.GetSecretAsync("ItemsServiceApiPorts").GetAwaiter().GetResult();

      return Host.CreateDefaultBuilder(args: args)
                 .UseServiceProviderFactory(factory: new AutofacServiceProviderFactory())
                 .ConfigureLogging(logging => { logging.AddSerilog(); })
                 .ConfigureWebHostDefaults(configure: webBuilder =>
                 {
                   webBuilder.UseKestrel();
                   webBuilder.UseUrls(urls);
                   webBuilder.UseStartup<Startup>();
                 });
    }
  }
}
