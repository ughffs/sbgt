using sbgt.Repository.Entities;

namespace sbgt.ServiceLogic.Services.Interfaces;

public interface IMemberService
{
    Task<Member> GetMemberByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<Member>> GetAllMembers(CancellationToken cancellationToken);
}