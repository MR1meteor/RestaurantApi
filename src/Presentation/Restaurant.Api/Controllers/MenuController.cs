using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("menu")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Menu>>> GetAllAsync()
    {
        var result = await _menuService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Menu>> GetByIdAsync([FromRoute] int id)
    {
        var result = await _menuService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Menu menu)
    {
        await _menuService.CreateAsync(menu);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] Menu menu)
    {
        await _menuService.UpdateAsync(menu);
        return Ok();
    }

    [HttpDelete("{id:int}")]

    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _menuService.DeleteByIdAsync(id);
        return Ok();
    }
}