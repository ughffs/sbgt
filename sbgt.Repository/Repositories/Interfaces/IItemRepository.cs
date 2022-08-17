using sbgt.Repository.Entities;

namespace sbgt.Repository.Repositories.Interfaces;

public interface IItemRepository
{
    Task<ItemEntity> GetItemByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<ItemEntity>> GetAllItems(CancellationToken cancellationToken);
}