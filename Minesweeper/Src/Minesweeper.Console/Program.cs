using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Services;
using Minesweeper.Core.Models;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Configure and register game settings
        var gameSettings = context.Configuration.GetSection("GameSettings").Get<GameSettings>();
        services.AddSingleton<IGameIO, GameIO>();
        services.AddTransient<GameService>(serviceProvider =>
            new GameService(
                gameSettings.BoardWidth,
                gameSettings.BoardHeight,
                gameSettings.Mines,
                gameSettings.Lives,
                serviceProvider.GetRequiredService<IGameIO>()
            ));
    });

var host = builder.Build();

// Resolve Game instance and start the game
var game = host.Services.GetRequiredService<GameService>();
game.Start();