using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using sbgt.Repository.Configuration;
using sbgt.Repository.Context;
using sbgt.Repository.Repositories;
using sbgt.Repository.Repositories.Interfaces;

namespace sbgt.Repository.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryDependencies(
        this IServiceCollection services, 
        DatabaseConfiguration dbConfig
    )
    {
        services.AddSingleton<DatabaseConfiguration>(dbConfig);
        
        var builder = new NpgsqlConnectionStringBuilder(dbConfig.ConnectionString);
        services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.ConnectionString));

        // Add repositories here
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }
}