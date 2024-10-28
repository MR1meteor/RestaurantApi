using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("menu-item")]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<MenuItem>>> GetAllAsync()
    {
        var result = await _menuItemService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MenuItem>> GetByIdAsync([FromRoute] int id)
    {
        var result = await _menuItemService.GetByIdAsync(id);
        return result == new MenuItem() ? BadRequest("Menu item not found") : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] MenuItem menuItem)
    {
        await _menuItemService.CreateAsync(menuItem);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] MenuItem menuItem)
    {
        await _menuItemService.UpdateAsync(menuItem);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _menuItemService.DeleteByIdAsync(id);
        return Ok();
    }
}