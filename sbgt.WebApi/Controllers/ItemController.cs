using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public ItemController(
        IItemService itemService,
        IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    [HttpGet("{id:Guid?}")]
    public async Task<ActionResult> GetItem(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var item = await _itemService.GetItemByGuid(id, cancellationToken);
        var mappedItem = _mapper.From(item).AdaptToType<ClientModel.Item>();
        return Ok(mappedItem);
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllItems(CancellationToken cancellationToken)
    {
        var items = await _itemService.GetAllItems(cancellationToken);
        var mappedItems = _mapper.From(items).AdaptToType<List<ClientModel.Summaries.ItemSummary>>();
        return Ok(mappedItems);
    }
}