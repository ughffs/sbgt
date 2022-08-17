using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RentEpisodeController : ControllerBase
{
    private readonly IRentEpisodeService _rentEpisodeService;
    private readonly IMapper _mapper;

    public RentEpisodeController(
        IRentEpisodeService rentEpisodeService,
        IMapper mapper)
    {
        _rentEpisodeService = rentEpisodeService;
        _mapper = mapper;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<ClientModel.RentEpisode>>> GetAllRentEpisodes(
        CancellationToken cancellationToken)
    {
        var episodes = await _rentEpisodeService.GetAllRentEpisodes(cancellationToken);
        var mappedEpisodes = _mapper.From(episodes).AdaptToType<List<ClientModel.RentEpisode>>();
        return Ok(mappedEpisodes);
    }
    
    [HttpGet("{id:Guid?}")]
    public async Task<ActionResult<ClientModel.RentEpisode>> GetRentEpisodeByEpisodeId(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var episode = await _rentEpisodeService.GetRentEpisodeById(id, cancellationToken);
        var mappedEpisode = _mapper.From(episode).AdaptToType<ClientModel.RentEpisode>();
        return Ok(mappedEpisode);
    }
    
    [HttpGet("Member/{id:Guid?}")]
    public async Task<ActionResult<List<ClientModel.RentEpisode>>> GetRentEpisodesByMemberId(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var episodes = await _rentEpisodeService.GetRentEpisodesByMemberId(id, cancellationToken);
        var mappedEpisode = _mapper.From(episodes).AdaptToType<List<ClientModel.RentEpisode>>();
        return Ok(mappedEpisode);
    }
    
}