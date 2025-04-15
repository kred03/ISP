using Lab5.Domain.Entities;

namespace Lab5.Domain.Interfaces;

public interface ISuperHeroRepository
{
    Task<Superhero> GetByIdAsync(Guid id);
    Task<IEnumerable<Superhero>> GetAllAsync();
    Task AddAsync(Superhero superhero);
    Task UpdateAsync(Superhero superhero);
    Task DeleteAsync(Guid id);
}