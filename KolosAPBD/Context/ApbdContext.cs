using KolosAPBD.Model;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD.Context;

public class ApbdContext : DbContext
{
    protected ApbdContext()
    {
    }

    public ApbdContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitle { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item()
            {
                Id = 1,
                Name = "Miecz swietlny",
                Weight = 10
            }
        });
        
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack()
            {
                CharacterID = 1,
                ItemID = 1,
                Amount = 5
            }
        });
        
        
        
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character()
            {
                CharacterID = 1,
                FirstName = "Anakin",
                LastName = "Skywalker",
                CurrentWeight = 80,
                MaxWeight = 120
            }
        });
        
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle()
            {
                CharacterID = 1,
                TitleID = 1,
                AcquiredAt = DateTime.Now
            }
        });
        
        
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title()
            {
                TitleID = 1,
                Name = "Jedi"
            }
        });
        
    }
}