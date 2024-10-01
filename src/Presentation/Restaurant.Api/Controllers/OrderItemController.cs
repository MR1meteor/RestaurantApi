using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("order-item")]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<OrderItem>> GetAllAsync()
    {
        var result = await _orderItemService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderItem>> GetByIdAsync([FromRoute] int id)
    {
        var result = await _orderItemService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] OrderItem orderItem)
    {
        await _orderItemService.CreateAsync(orderItem);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] OrderItem orderItem)
    {
        await _orderItemService.UpdateAsync(orderItem);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _orderItemService.DeleteByIdAsync(id);
        return Ok();
    }
}