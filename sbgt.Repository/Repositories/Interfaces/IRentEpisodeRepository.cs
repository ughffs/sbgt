using sbgt.Repository.Entities;

namespace sbgt.Repository.Repositories.Interfaces;

public interface IRentEpisodeRepository
{
    Task<List<RentEpisode>> GetRentEpisodesByMemberId(Guid memberId, CancellationToken cancellationToken);
    Task<List<RentEpisode>> GetAllRentEpisodes(CancellationToken cancellationToken);
    Task<RentEpisode> GetRentEpisodeById(Guid id, CancellationToken cancellationToken);
}