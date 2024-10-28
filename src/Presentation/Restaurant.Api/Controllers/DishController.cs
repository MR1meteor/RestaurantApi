using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Helpers;
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
        return result.IsSuccess
            ? Ok(result.Data)
            : StatusCode((int)HttpErrorConverter.ConvertToHttp(result.Error), result.Error?.Message);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dish>> GetByIdAsync([FromRoute] string id)
    {
        var result = await _dishService.GetByIdAsync(id);
        return result.IsSuccess
            ? Ok(result.Data)
            : StatusCode((int)HttpErrorConverter.ConvertToHttp(result.Error), result.Error?.Message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Dish dish)
    {
        var result = await _dishService.CreateAsync(dish);
        return result.IsSuccess
            ? Ok()
            : StatusCode((int)HttpErrorConverter.ConvertToHttp(result.Error), result.Error?.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] Dish dish)
    {
        var result = await _dishService.UpdateAsync(dish);
        return result.IsSuccess
            ? Ok()
            : StatusCode((int)HttpErrorConverter.ConvertToHttp(result.Error), result.Error?.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute] string id)
    {
        var result = await _dishService.DeleteByIdAsync(id);
        return result.IsSuccess
            ? Ok()
            : StatusCode((int)HttpErrorConverter.ConvertToHttp(result.Error), result.Error?.Message);
    }
}