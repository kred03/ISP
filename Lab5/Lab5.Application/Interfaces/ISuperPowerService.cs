using Lab5.Application.DTOs;

namespace Lab5.Application.Interfaces;

public interface ISuperPowerService
{
    Task<SuperpowerDto> GetSuperpowerByIdAsync(Guid id);
    Task<IEnumerable<SuperpowerDto>> GetAllSuperpowersAsync();
    Task<SuperpowerDto> CreateSuperpowerAsync(SuperpowerDto superpowerDto);
    Task<SuperpowerDto> UpdateSuperpowerAsync(Guid id, SuperpowerDto superpowerDto);
    Task DeleteSuperpowerAsync(Guid id);
}