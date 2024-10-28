using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Order>>> GetAllAsync()
    {
        var result = await _orderService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetByIdAsync([FromRoute] int id)
    {
        var result = await _orderService.GetByIdAsync(id);
        return result == new Order() ? BadRequest("Order not found") : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Order order)
    {
        await _orderService.CreateAsync(order);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] Order order)
    {
        await _orderService.UpdateAsync(order);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _orderService.DeleteByIdAsync(id);
        return Ok();
    }
}