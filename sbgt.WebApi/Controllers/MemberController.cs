using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;
    private readonly IMapper _mapper;

    public MemberController(
        IMemberService memberService,
        IMapper mapper)
    {
        _memberService = memberService;
        _mapper = mapper;
    }

    [HttpGet("{id:Guid?}")]
    public async Task<ActionResult<ClientModel.Member>> GetMember(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var member = await _memberService.GetMemberByGuid(id, cancellationToken);
        var mappedMember = _mapper.From(member).AdaptToType<ClientModel.Member>();
        return Ok(mappedMember);
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllmembers(CancellationToken cancellationToken)
    {
        var members = await _memberService.GetAllMembers(cancellationToken);
        var mappedMembers = _mapper.From(members).AdaptToType<List<ClientModel.Summaries.MemberSummary>>();
        return Ok(mappedMembers);
    }
}