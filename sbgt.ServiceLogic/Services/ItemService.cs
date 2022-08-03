using MapsterMapper;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.ServiceLogic.Services;

public class ItemService : IItemService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Item> _baseRepostory;

    public ItemService(
        IMapper mapper,
        IBaseRepository<Item> baseRepostory)
    {
        _mapper = mapper;
        _baseRepostory = baseRepostory;
    }
    
    public async Task GetItemByGuid(Guid guid, CancellationToken cancellationToken)
    {
        var result = await _baseRepostory.GetByIdWithNavigationProperties(guid, i => i.RentEpisodes);
        
    }
}