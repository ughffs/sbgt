using sbgt.Repository.Entities;

namespace sbgt. ServiceLogic.Services.Interfaces;

public interface IItemService
{
    Task<ItemEntity> GetItemByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<ItemEntity>> GetAllItems(CancellationToken cancellationToken);
}