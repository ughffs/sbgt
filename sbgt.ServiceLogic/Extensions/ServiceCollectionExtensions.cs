using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using sbgt.Repository.Configuration;
using sbgt.Repository.Context;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories;
using sbgt.Repository.Repositories.Interfaces;
using sbgt.ServiceLogic.Services;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.ServiceLogic.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        var mappingConfig = new TypeAdapterConfig();
        mappingConfig.NewConfig<Member, ClientModel.Member>();

        services.AddSingleton(mappingConfig);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IMemberService, MemberService>();

        return services;
    }
}