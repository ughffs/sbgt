using sbgt.Repository.Entities;

namespace sbgt.Repository.Repositories.Interfaces;

public interface IMemberRepository
{
    Task<MemberEntity> GetMemberByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<MemberEntity>> GetAllMembers(CancellationToken cancellationToken);
}