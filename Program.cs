using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sm_coding_challenge.Persistence.Context;
using Serilog;
using System;
using Serilog.Events;
using Microsoft.Extensions.Configuration;

namespace sm_coding_challenge
{
    public class Program
    {
        private static IConfiguration Configuration
        {
            get
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile($"appsettings.{env}.json", false, true);

                builder.AddEnvironmentVariables();
                return builder.Build();
            }
        }
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            //.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            //.Enrich.FromLogContext()
            //.WriteTo.Console()
            // .WriteTo.File("log.txt",
            //     rollingInterval: RollingInterval.Day,
            //     rollOnFileSizeLimit: true)
            //.WriteTo.RollingFile("api-log-{Date}.txt")
            .CreateLogger();

            try
            {
                Log.Information("Starting up");
                var host = CreateHostBuilder(args).UseSerilog().Build();
                using (var scope = host.Services.CreateScope())
                using (var context = scope.ServiceProvider.GetService<AppDbContext>())
                {
                    context.Database.EnsureCreated();
                }

                host.Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
