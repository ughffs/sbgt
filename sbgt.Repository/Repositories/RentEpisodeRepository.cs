using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Context;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;

namespace sbgt.Repository.Repositories;

public class RentEpisodeRepository : BaseRepository<RentEpisodeEntity>, IRentEpisodeRepository
{
    public RentEpisodeRepository(DataContext context) 
        : base(context)
    {
    }

    public async Task<List<RentEpisodeEntity>> GetRentEpisodesByMemberId(
        Guid memberId,
        CancellationToken cancellationToken)
    {
        var episodes = await AsQueryableWithNavigationProperties
            .Where(re => re.Rentee.Id == memberId)
            .ToListAsync(cancellationToken);

        return episodes;
    }

    public async Task<List<RentEpisodeEntity>> GetAllRentEpisodes(CancellationToken cancellationToken)
    {
        return await AsQueryableWithNavigationProperties.ToListAsync(cancellationToken);
    }

    public async Task<RentEpisodeEntity> GetRentEpisodeById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var episode = await AsQueryableWithNavigationProperties
            .SingleOrDefaultAsync(re => re.Id == id, cancellationToken);

        return episode;
    }

    private IQueryable<RentEpisodeEntity> AsQueryableWithNavigationProperties =>
        Context.RentEpisodes
            .Include(re => re.Item)
            .Include(re => re.Rentee);
}