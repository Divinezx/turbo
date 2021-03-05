using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using Turbo.Core.Configuration;
using Turbo.Database.Context;
using Turbo.Main.Configuration;
using Turbo.Plugins;
using Microsoft.EntityFrameworkCore;
using Turbo.Players;
using Turbo.Rooms;
using Turbo.Database.Repositories;
using Turbo.Networking;
using Turbo.Networking.Game;
using Turbo.Networking.Game.WebSocket;
using Turbo.Networking.REST;
using Turbo.Networking.EventLoop;
using Turbo.Packets.Revisions;
using Turbo.Networking.Clients;
using Turbo.Packets;
using Turbo.Networking.Game.Clients;
using Turbo.Database.Repositories.Player;
using System.Reflection;
using System.Linq;
using Turbo.Database.Repositories.Furniture;
using Turbo.Furniture;
using Turbo.Security;
using Turbo.Database.Repositories.Security;
using Turbo.Database.Entities.Security;
using Turbo.Main.Extensions;

namespace Turbo.Main
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(hostContext.Configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

                    // Configuration
                    var turboConfig = new TurboConfig();
                    hostContext.Configuration.Bind(TurboConfig.Turbo, turboConfig);
                    services.AddSingleton<IEmulatorConfig>(turboConfig);

                    // DB Context
                    var connectionString = $"server={turboConfig.DatabaseHost};user={turboConfig.DatabaseUser};password={turboConfig.DatabasePassword};database={turboConfig.DatabaseName}";
                    services.AddDbContext<IEmulatorContext, TurboContext>(options => options
                        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                        .EnableSensitiveDataLogging(turboConfig.DatabaseLoggingEnabled)
                        .EnableDetailedErrors(),
                        ServiceLifetime.Singleton
                    );

                    // Repositories, Managers and networking
                    services.AddRepositories();
                    services.AddManagers();
                    services.AddNetworking();

                    // Emulator
                    services.AddHostedService<TurboEmulator>();
                }).UseSerilog();
    }
}
