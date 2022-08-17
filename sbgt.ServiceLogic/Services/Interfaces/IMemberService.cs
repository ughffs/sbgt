using sbgt.Repository.Entities;

namespace sbgt.ServiceLogic.Services.Interfaces;

public interface IMemberService
{
    Task<MemberEntity> GetMemberByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<MemberEntity>> GetAllMembers(CancellationToken cancellationToken);
}