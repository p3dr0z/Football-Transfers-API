namespace FootballTransfersAPI.Extensions;

using FootballTransfersAPI.Data.Mappers;
using FootballTransfersAPI.Data.Services;
using FootballTransfersAPI.Data.Services.Interfaces;
using FootballTransfersAPI.Data.Services.Interfaces.Messaging;
using FootballTransfersAPI.Data.Services.Messaging;
using FootballTransfersAPI.Model.Context;
using FootballTransfersAPI.Model.Repository;
using FootballTransfersAPI.Model.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddContext(this IServiceCollection services,
        string? connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        return services;
    }

    public static IServiceCollection AddRepositoryGroup(this IServiceCollection services)
    {
        services.AddScoped<IClubsRepository, ClubsRepository>();
        services.AddScoped<IPlayersRepository, PlayersRepository>();
        services.AddScoped<ITransfersRepository, TransfersRepository>();

        return services;
    }

    public static IServiceCollection AddDataServicesGroup(this IServiceCollection services)
    {
        services.AddScoped<IClubsDataService, ClubsDataService>();
        services.AddScoped<IPlayersDataService, PlayersDataService>();
        services.AddScoped<ITransfersDataService, TransfersDataService>();
        services.AddScoped<IMessageProducerService, MessageProducerService>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(ClubProfile),
            typeof(PlayerProfile),
            typeof(TransferProfile));

        return services;
    }
}
