using sbgt.ClientModel;

namespace sbgt.ServiceLogic.Services.Interfaces;

public interface IMemberService
{
    Task<Member> GetMemberByGuid(Guid guid, CancellationToken cancellationToken);
}