using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Application.DTOs;

public class SuperpowerDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int StrengthLevel { get; set; }
}