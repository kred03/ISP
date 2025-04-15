using Lab5.Application.DTOs;
using Lab5.Application.Interfaces;
using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;



namespace Lab5.Application.Services
{
    public class SuperPowerService : ISuperPowerService
    {
        private readonly ApplicationDbContext _context;

        public SuperPowerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SuperpowerDto> GetSuperpowerByIdAsync(Guid id)
        {
            var superpower = await _context.Superpowers
                .FirstOrDefaultAsync(sp => sp.Id == id);

            if (superpower == null)
                throw new KeyNotFoundException($"Superpower with id {id} not found");

            return new SuperpowerDto
            {
                Id = superpower.Id,
                Name = superpower.Name,
                StrengthLevel = superpower.StrengthLevel
            };
        }

        public async Task<IEnumerable<SuperpowerDto>> GetAllSuperpowersAsync()
        {
            var superpowers = await _context.Superpowers.ToListAsync();

            return superpowers.Select(sp => new SuperpowerDto
            {
                Id = sp.Id,
                Name = sp.Name,
                StrengthLevel = sp.StrengthLevel
            });
        }

        public async Task<SuperpowerDto> CreateSuperpowerAsync(SuperpowerDto superpowerDto)
        {
            var superpower = new Superpower
            {
                Id = superpowerDto.Id,
                Name = superpowerDto.Name,
                StrengthLevel = superpowerDto.StrengthLevel
            };

            _context.Superpowers.Add(superpower);
            await _context.SaveChangesAsync();

            return new SuperpowerDto
            {
                Id = superpower.Id,
                Name = superpower.Name,
                StrengthLevel = superpower.StrengthLevel
            };
        }

        public async Task<SuperpowerDto> UpdateSuperpowerAsync(Guid id, SuperpowerDto superpowerDto)
        {
            var superpower = await _context.Superpowers
                .FirstOrDefaultAsync(sp => sp.Id == id);

            if (superpower == null)
                throw new KeyNotFoundException($"Superpower with id {id} not found");

            superpower.Name = superpowerDto.Name;
            superpower.StrengthLevel = superpowerDto.StrengthLevel;

            _context.Superpowers.Update(superpower);
            await _context.SaveChangesAsync();

            return new SuperpowerDto
            {
                Id = superpower.Id,
                Name = superpower.Name,
                StrengthLevel = superpower.StrengthLevel
            };
        }

        public async Task DeleteSuperpowerAsync(Guid id)
        {
            var superpower = await _context.Superpowers
                .FirstOrDefaultAsync(sp => sp.Id == id);

            if (superpower == null)
                throw new KeyNotFoundException($"Superpower with id {id} not found");

            _context.Superpowers.Remove(superpower);
            await _context.SaveChangesAsync();
        }
    }
}
