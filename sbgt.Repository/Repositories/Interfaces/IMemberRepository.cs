using sbgt.Repository.Entities;

namespace sbgt.Repository.Repositories.Interfaces;

public interface IMemberRepository
{
    Task<Member> GetMemberByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<Member>> GetAllMembers(CancellationToken cancellationToken);
}