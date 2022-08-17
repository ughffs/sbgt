using sbgt.Repository.Entities;
using sbgt.Repository.Repositories;
using sbgt.Repository.Repositories.Interfaces;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.ServiceLogic.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<MemberEntity> GetMemberByGuid(Guid guid, CancellationToken cancellationToken)
    {
        var fetchedMember = await _memberRepository.GetMemberByGuid(guid, cancellationToken);
        return fetchedMember;
    }

    public async Task<List<MemberEntity>> GetAllMembers(CancellationToken cancellationToken)
    {
        var fetchedMembers = await _memberRepository.GetAllMembers(cancellationToken);
        return fetchedMembers;
    }
}