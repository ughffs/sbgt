using sbgt.Repository.Entities;

namespace sbgt.Repository.Repositories.Interfaces;

public interface IItemRepository
{
    Task<Item> GetItemByGuid(Guid guid, CancellationToken cancellationToken);
}