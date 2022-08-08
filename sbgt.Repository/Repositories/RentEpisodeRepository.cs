using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Context;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;

namespace sbgt.Repository.Repositories;

public class RentEpisodeRepository : BaseRepository<RentEpisode>, IRentEpisodeRepository
{
    public RentEpisodeRepository(DataContext context) 
        : base(context)
    {
    }

    public async Task<List<RentEpisode>> GetRentEpisodesByMemberId(
        Guid memberId,
        CancellationToken cancellationToken)
    {
        var episodes = await AsQueryableWithNavigationProperties
            .Where(re => re.Rentee.Id == memberId)
            .ToListAsync(cancellationToken);

        return episodes;
    }

    public async Task<List<RentEpisode>> GetAllRentEpisodes(CancellationToken cancellationToken)
    {
        return await AsQueryableWithNavigationProperties.ToListAsync(cancellationToken);
    }

    public async Task<RentEpisode> GetRentEpisodeById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var episode = await AsQueryableWithNavigationProperties
            .SingleOrDefaultAsync(re => re.Id == id, cancellationToken);

        return episode;
    }

    private IQueryable<RentEpisode> AsQueryableWithNavigationProperties =>
        Context.RentEpisodes
            .Include(re => re.Item)
            .Include(re => re.Rentee);
}