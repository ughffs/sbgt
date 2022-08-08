using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using sbgt.ClientModel.Summaries;
using sbgt.Repository.Entities;
using sbgt.ServiceLogic.Services;
using sbgt.ServiceLogic.Services.Interfaces;
using RentEpisodeSummary = sbgt.ClientModel.Summaries.RentEpisodeSummary;

namespace sbgt.ServiceLogic.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        var mappingConfig = new TypeAdapterConfig();
        mappingConfig.NewConfig<Member, ClientModel.Member>();
        mappingConfig.NewConfig<Member, MemberSummary>();
        mappingConfig.NewConfig<Item, ClientModel.Item>();
        mappingConfig.NewConfig<Item, ItemSummary>();
        mappingConfig.NewConfig<RentEpisode, ClientModel.RentEpisode>();
        mappingConfig.NewConfig<RentEpisode, RentEpisodeSummary>();

        services.AddSingleton(mappingConfig);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IRentEpisodeService, RentEpisodeService>();

        return services;
    }
}