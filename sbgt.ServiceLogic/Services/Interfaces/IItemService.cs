using sbgt.Repository.Entities;

namespace sbgt. ServiceLogic.Services.Interfaces;

public interface IItemService
{
    Task<Item> GetItemByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<Item>> GetAllItems(CancellationToken cancellationToken);
}