using Microsoft.AspNetCore.Mvc;

namespace sbgt.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    public ItemController()
    {
    }

    [HttpGet("{id:Guid?}")]
    public async Task<ActionResult> GetItem(Guid id)
    {
        return Ok(id);
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAllItems()
    {
        return Ok("Test");
    }
}