using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Domain.Entities;

public class Superpower
{
    [Column("Id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    public int StrengthLevel { get; set; }

    public Guid SuperheroId { get; set; }
    public Superhero Superhero { get; set; }
}