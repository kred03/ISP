using System.ComponentModel.DataAnnotations.Schema;
using Lab5.Domain.Enums;

namespace Lab5.Domain.Entities
{
    public class Superhero
    {
        [Column("Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty; 
        public PowerLevel PowerLevel { get; set; } = PowerLevel.Low;
        public byte[]? Photo { get; set; } = Array.Empty<byte>();

        public ICollection<Superpower> Superpowers { get; set; } = new List<Superpower>();
    }
}