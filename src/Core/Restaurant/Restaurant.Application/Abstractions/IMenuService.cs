using Restaurant.Application.Domain.Domain;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IMenuService : ITransient
{
    Task<List<Menu>> GetAllAsync();
    Task<Menu?> GetByIdAsync(int id);
    Task CreateAsync(Menu menu);
    Task UpdateAsync(Menu menu);
    Task DeleteByIdAsync(int id);
}