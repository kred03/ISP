using Lab5.Domain.Entities;
using Lab5.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Infrastracture.Repositories;

public class SuperHeroRepository : ISuperHeroRepository
{
    private readonly ApplicationDbContext _context;

    public SuperHeroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Superhero> GetByIdAsync(Guid id)
    {
        return await _context.Superheroes
            .Include(s => s.Superpowers) 
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Superhero>> GetAllAsync()
    {
        return await _context.Superheroes
            .Include(s => s.Superpowers)
            .ToListAsync();
    }

    public async Task AddAsync(Superhero superhero)
    {
        await _context.Superheroes.AddAsync(superhero);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Superhero superhero)
    {
        _context.Superheroes.Update(superhero);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var superhero = await GetByIdAsync(id);
        if (superhero != null)
        {
            _context.Superheroes.Remove(superhero);
            await _context.SaveChangesAsync();
        }
    }
}