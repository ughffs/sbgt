using sbgt.Repository.Entities;

namespace sbgt.Repository.Repositories.Interfaces;

public interface IRentEpisodeRepository
{
    Task<List<RentEpisodeEntity>> GetRentEpisodesByMemberId(Guid memberId, CancellationToken cancellationToken);
    Task<List<RentEpisodeEntity>> GetAllRentEpisodes(CancellationToken cancellationToken);
    Task<RentEpisodeEntity> GetRentEpisodeById(Guid id, CancellationToken cancellationToken);
}