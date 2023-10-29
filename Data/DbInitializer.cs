using Learn_ASP.NET_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Learn_ASP.NET_CRUD.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                // Check if data already exists
                if (context.Weapons.Any() || context.Characters.Any() || context.Factions.Any())
                {
                    return; // Data has already been seeded
                }

                // Create Characters
                var character1 = new Character { Name = "Atilla" };
                var character2 = new Character { Name = "John" };

                context.Characters.AddRange(character1, character2);

                // Create Factions
                var faction1 = new Faction { Name = "Knights" };
                var faction2 = new Faction { Name = "Barbarians" };

                context.Factions.AddRange(faction1, faction2);

                // Initialize the Factions collection within characters
                character1.Factions = new List<Faction>();
                character2.Factions = new List<Faction>();

                // Associate Characters with Factions
                character1.Factions.Add(faction1);
                character1.Factions.Add(faction2);
                character2.Factions.Add(faction2);

                // Create Weapons
                var weapon1 = new Weapon { Name = "Axe", Character = character1 };
                var weapon2 = new Weapon { Name = "Bow", Character = character2 };

                context.Weapons.AddRange(weapon1, weapon2);

                // Create Backpacks
                var backpack1 = new Backpack { Name = "Backpack 1", Character = character1 };
                var backpack2 = new Backpack { Name = "Backpack 2", Character = character2 };

                context.Backpacks.AddRange(backpack1, backpack2);

                context.SaveChanges();
            }
        }
    }
}
