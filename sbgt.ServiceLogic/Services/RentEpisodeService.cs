using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.ServiceLogic.Services;

public class RentEpisodeService : IRentEpisodeService
{
    private readonly IRentEpisodeRepository _rentEpisodeRepository;

    public RentEpisodeService(IRentEpisodeRepository rentEpisodeRepository)
    {
        _rentEpisodeRepository = rentEpisodeRepository;
    }
    
    public async Task<List<RentEpisode>> GetRentEpisodesByMemberId(
        Guid guid,
        CancellationToken cancellationToken)
    {
        var episodes = await _rentEpisodeRepository
            .GetRentEpisodesByMemberId(guid, cancellationToken);

        return episodes;
    }

    public async Task<List<RentEpisode>> GetAllRentEpisodes(CancellationToken cancellationToken)
    {
        return await _rentEpisodeRepository
            .GetAllRentEpisodes(cancellationToken);
    }

    public async Task<RentEpisode> GetRentEpisodeById(
        Guid id, 
        CancellationToken cancellationToken)
    {
        var episode = await _rentEpisodeRepository
            .GetRentEpisodeById(id, cancellationToken);

        return episode;
    }
}