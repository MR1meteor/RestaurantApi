using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("dish")]
public class DishController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Dish>>> GetAllAsync()
    {
        var result = await _dishService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Dish>> GetByIdAsync([FromRoute] int id)
    {
        var result = await _dishService.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Dish dish)
    {
        await _dishService.CreateAsync(dish);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] Dish dish)
    {
        await _dishService.UpdateAsync(dish);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
    {
        await _dishService.DeleteByIdAsync(id);
        return Ok();
    }
}