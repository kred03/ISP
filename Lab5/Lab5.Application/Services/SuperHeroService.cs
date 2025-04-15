using AutoMapper;
using Lab5.Application.DTOs;
using Lab5.Application.Interfaces;
using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Application.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SuperHeroService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SuperheroDto> GetSuperheroByIdAsync(Guid id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Superpowers)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null)
                throw new KeyNotFoundException($"Superhero with id {id} not found");

            return _mapper.Map<SuperheroDto>(superhero); 
        }

        public async Task<IEnumerable<SuperheroDto>> GetAllSuperheroesAsync()
        {
            var superheroes = await _context.Superheroes
                .Include(s => s.Superpowers)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SuperheroDto>>(superheroes); 
        }

        public async Task<SuperheroDto> CreateSuperheroAsync(SuperheroDto superheroDto)
        {
            var superhero = _mapper.Map<Superhero>(superheroDto); 

            _context.Superheroes.Add(superhero);
            await _context.SaveChangesAsync();

            return _mapper.Map<SuperheroDto>(superhero); 
        }

        public async Task<SuperheroDto> UpdateSuperheroAsync(Guid id, SuperheroDto superheroDto)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Superpowers)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null)
                throw new KeyNotFoundException($"Superhero with id {id} not found");

            // Update properties
            _mapper.Map(superheroDto, superhero); 

            _context.Superheroes.Update(superhero);
            await _context.SaveChangesAsync();

            return _mapper.Map<SuperheroDto>(superhero);
        }

        public async Task DeleteSuperheroAsync(Guid id)
        {
            var superhero = await _context.Superheroes
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null)
                throw new KeyNotFoundException($"Superhero with id {id} not found");

            _context.Superheroes.Remove(superhero);
            await _context.SaveChangesAsync();
        }
    }
}
