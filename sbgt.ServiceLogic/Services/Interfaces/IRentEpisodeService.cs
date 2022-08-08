using sbgt.Repository.Entities;

namespace sbgt.ServiceLogic.Services.Interfaces;

public interface IRentEpisodeService
{
    Task<List<RentEpisode>> GetRentEpisodesByMemberId(Guid guid, CancellationToken cancellationToken);
    Task<List<RentEpisode>> GetAllRentEpisodes(CancellationToken cancellationToken);
    Task<RentEpisode> GetRentEpisodeById(Guid id, CancellationToken cancellationToken);
}