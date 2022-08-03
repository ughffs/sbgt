using MapsterMapper;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.ServiceLogic.Services;

public class MemberService : IMemberService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Member> _baseRepostory;

    public MemberService(
        IMapper mapper,
        IBaseRepository<Member> baseRepostory)
    {
        _mapper = mapper;
        _baseRepostory = baseRepostory;
    }
    
    public async Task<ClientModel.Member> GetMemberByGuid(Guid guid, CancellationToken cancellationToken)
    {
        var fetchedMember = await _baseRepostory.GetById(guid);

        return _mapper.From(fetchedMember).AdaptToType<ClientModel.Member>();
    }
}