using sbgt.Repository.Entities;

namespace sbgt.ServiceLogic.Services.Interfaces;

public interface IRentEpisodeService
{
    Task<List<RentEpisodeEntity>> GetRentEpisodesByMemberId(Guid guid, CancellationToken cancellationToken);
    Task<List<RentEpisodeEntity>> GetAllRentEpisodes(CancellationToken cancellationToken);
    Task<RentEpisodeEntity> GetRentEpisodeById(Guid id, CancellationToken cancellationToken);
}