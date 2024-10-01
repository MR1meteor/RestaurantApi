using Restaurant.Application.Abstractions;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Mappers;

namespace Restaurant.Application;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }
    
    public async Task<List<MenuItem>> GetAllAsync()
    {
        var menuItems = await _menuItemRepository.GetAllAsync();
        return menuItems.MapToDomain();
    }

    public async Task<MenuItem?> GetByIdAsync(int id)
    {
        var menuItem = await _menuItemRepository.GetByIdAsync(id);
        return menuItem.MapToDomain();
    }

    public async Task CreateAsync(MenuItem menu)
    {
        await _menuItemRepository.CreateAsync(menu.MapToDb());
    }

    public async Task UpdateAsync(MenuItem menu)
    {
        await _menuItemRepository.UpdateAsync(menu.MapToDb());
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _menuItemRepository.DeleteByIdAsync(id);
    }
}