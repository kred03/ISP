using Lab5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Superhero> Superheroes { get; set; }
    public DbSet<Superpower> Superpowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       modelBuilder.Entity<Superhero>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Alias)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PowerLevel)
                .HasConversion<int>();  

            entity.HasMany(e => e.Superpowers)
                .WithOne(s => s.Superhero)  
                .HasForeignKey(s => s.SuperheroId); 
        });

        modelBuilder.Entity<Superpower>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.StrengthLevel)
                .IsRequired();
        });
    }
}