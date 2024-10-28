using Restaurant.Application.Abstractions;
using Restaurant.Application.Abstractions.Postgres;
using Restaurant.Application.Domain.Domain;
using Restaurant.Application.Domain.Mappers;

namespace Restaurant.Application;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        var menus = await _menuRepository.GetAllAsync();
        return menus.MapToDomain();
    }

    public async Task<Menu?> GetByIdAsync(int id)
    {
        var menu = await _menuRepository.GetByIdAsync(id);
        return menu.MapToDomain();
    }

    public async Task CreateAsync(Menu menu)
    {
        await _menuRepository.CreateAsync(menu.MapToDb());
    }

    public async Task UpdateAsync(Menu menu)
    {
        await _menuRepository.UpdateAsync(menu.MapToDb());
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _menuRepository.DeleteByIdAsync(id);
    }
}