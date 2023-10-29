using Learn_ASP.NET_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_ASP.NET_CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Faction> Factions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-one relationship between Character and Backpack
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Backpack)
                .WithOne(b => b.Character)
                .HasForeignKey<Backpack>(b => b.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-many relationship between Character and Weapon
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Weapons)
                .WithOne(w => w.Character)
                .HasForeignKey(w => w.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the many-to-many relationship between Character and Faction
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Factions)
                .WithMany(f => f.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterFaction",
                    join => join
                        .HasOne<Faction>()
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .HasConstraintName("FK_CharacterFaction_Factions_FactionId")
                        .OnDelete(DeleteBehavior.Restrict), // Do not delete factions when characters are deleted
                    join => join
                        .HasOne<Character>()
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .HasConstraintName("FK_CharacterFaction_Characters_CharacterId")
                        .OnDelete(DeleteBehavior.Restrict) // Do not delete characters when factions are deleted
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
