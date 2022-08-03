using Microsoft.AspNetCore.Mvc;
using sbgt.ServiceLogic.Services.Interfaces;

namespace sbgt.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet("{id:Guid?}")]
    public async Task<ActionResult> GetItem(Guid id)
    {
        return Ok(id);
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllItems(CancellationToken cancellationToken)
    {
        var items = await _itemService.GetAllItems(cancellationToken);

        return Ok(items);
    }
}