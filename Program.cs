using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlaceOrderConsoleApp;
using PlaceOrderConsoleApp.Data;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    await services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An unhandled exception occurred.");
}


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            // services.Add...
            services.AddDbContext<PlaceOrderDbContext>(options =>
                options.UseSqlite("Data Source=PlaceOrderAppDB.db"));
            services.AddScoped<App>();
        })
        .ConfigureLogging((_, logging) =>
        {
            // Disable EF logs
            logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.None);
            logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.None);
        });
}
