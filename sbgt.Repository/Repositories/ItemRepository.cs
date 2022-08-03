using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Context;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;

namespace sbgt.Repository.Repositories;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    public ItemRepository(DataContext context)
        : base(context)
    {
    }
    
    public async Task<Item> GetItemByGuid(Guid guid, CancellationToken cancellationToken)
    {
        var fetchedItem = await AsQueryableWithNavigationProperties
            .SingleOrDefaultAsync(i => i.Id == guid, cancellationToken);

        return fetchedItem;
    }

    public IQueryable<Item> AsQueryableWithNavigationProperties =>
        Context.Items
            .Include(i => i.Owner)
            .Include(i => i.RentEpisodes)
                .ThenInclude(re => re.Item)
            .Include(i => i.RentEpisodes)
                .ThenInclude(re => re.Rentee);
}