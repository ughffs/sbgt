using Microsoft.AspNetCore.Mvc;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpGet("{id:Guid?}")]
    public async Task<ActionResult<ClientModel.Member>> GetMember(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var member = await _memberService.GetMemberByGuid(id, cancellationToken);    
        return Ok(member);
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllmembers()
    {
        return Ok("Test");
    }
}