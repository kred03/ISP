using Lab5.Domain.Entities;

namespace Lab5.Domain.Interfaces;

public interface ISuperpowerRepository
{
    Task<Superpower> GetByIdAsync(Guid id);
    Task<IEnumerable<Superpower>> GetAllAsync();
    Task AddAsync(Superpower superpower);
    Task UpdateAsync(Superpower superpower);
    Task DeleteAsync(Guid id);
}