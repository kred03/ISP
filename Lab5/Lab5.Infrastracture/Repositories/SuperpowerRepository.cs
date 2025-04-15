using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Infrastracture.Repositories;

public class SuperPowerRepository : ISuperpowerRepository
{
    private readonly ApplicationDbContext _context;

    public SuperPowerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Superpower> GetByIdAsync(Guid id)
    {
        return await _context.Superpowers
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Superpower>> GetAllAsync()
    {
        return await _context.Superpowers.ToListAsync();
    }

    public async Task AddAsync(Superpower superpower)
    {
        await _context.Superpowers.AddAsync(superpower);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Superpower superpower)
    {
        _context.Superpowers.Update(superpower);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var superpower = await GetByIdAsync(id);
        if (superpower != null)
        {
            _context.Superpowers.Remove(superpower);
            await _context.SaveChangesAsync();
        }
    }
}
