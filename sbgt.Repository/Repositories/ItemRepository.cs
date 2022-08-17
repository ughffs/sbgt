using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Context;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;

namespace sbgt.Repository.Repositories;

public class ItemRepository : BaseRepository<ItemEntity>, IItemRepository
{
    public ItemRepository(DataContext context)
        : base(context)
    {
    }
    
    public async Task<ItemEntity> GetItemByGuid(Guid guid, CancellationToken cancellationToken)
    {
        var fetchedItem = await AsQueryableWithNavigationProperties
            .SingleOrDefaultAsync(i => i.Id == guid, cancellationToken);

        return fetchedItem;
    }

    public async Task<List<ItemEntity>> GetAllItems(CancellationToken cancellationToken)
    {
        return await AsQueryableWithNavigationProperties.ToListAsync(cancellationToken);
    }

    public IQueryable<ItemEntity> AsQueryableWithNavigationProperties =>
        Context.Items
            .Include(i => i.Owner)
            .Include(i => i.RentEpisodes)
                .ThenInclude(re => re.Rentee);
}