using Learn_ASP.NET_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_ASP.NET_CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Character> Character { get; set; }
        public DbSet<Backpack> Backpack { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Faction> Factions { get; set; }
    }
}
