using MapsterMapper;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.ServiceLogic.Services;

public class ItemService : IItemService
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _itemRepostory;

    public ItemService(
        IMapper mapper,
        IItemRepository itemRepostory)
    {
        _mapper = mapper;
        _itemRepostory = itemRepostory;
    }
    
    public async Task<ClientModel.Item> GetItemByGuid(Guid guid, CancellationToken cancellationToken)
    {
        var fetchedItem = await _itemRepostory.GetItemByGuid(guid, cancellationToken);
        
        return _mapper.From(fetchedItem).AdaptToType<ClientModel.Item>();
    }

    public async Task<List<ClientModel.Item>> GetAllItems(CancellationToken cancellationToken)
    {
        var fetchedItems = await _itemRepostory.GetAllItems(cancellationToken);

        return _mapper.From(fetchedItems).AdaptToType<List<ClientModel.Item>>();
    }
}