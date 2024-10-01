using Restaurant.Application.Domain.Domain;
using Restaurant.Common.DependencyInjection.Interfaces;

namespace Restaurant.Application.Abstractions;

public interface IMenuItemService : ITransient
{
    Task<List<MenuItem>> GetAllAsync();
    Task<MenuItem?> GetByIdAsync(int id);
    Task CreateAsync(MenuItem menu);
    Task UpdateAsync(MenuItem menu);
    Task DeleteByIdAsync(int id);
}