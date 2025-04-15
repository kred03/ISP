using Lab5.Application.DTOs;

namespace Lab5.Application.Interfaces;

public interface ISuperHeroService
{
    Task<SuperheroDto> GetSuperheroByIdAsync(Guid id);
    Task<IEnumerable<SuperheroDto>> GetAllSuperheroesAsync();
    Task<SuperheroDto> CreateSuperheroAsync(SuperheroDto superheroDto);
    Task<SuperheroDto> UpdateSuperheroAsync(Guid id, SuperheroDto superheroDto);
    Task DeleteSuperheroAsync(Guid id);
}