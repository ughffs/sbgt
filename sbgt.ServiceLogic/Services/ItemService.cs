using MapsterMapper;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.ServiceLogic.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepostory;

    public ItemService(IItemRepository itemRepostory)
    {
        _itemRepostory = itemRepostory;
    }
    
    public async Task<ItemEntity> GetItemByGuid(Guid guid, CancellationToken cancellationToken)
    {
        var fetchedItem = await _itemRepostory.GetItemByGuid(guid, cancellationToken);
        return fetchedItem;
    }

    public async Task<List<ItemEntity>> GetAllItems(CancellationToken cancellationToken)
    {
        var fetchedItems = await _itemRepostory.GetAllItems(cancellationToken);
        return fetchedItems;
    }
}