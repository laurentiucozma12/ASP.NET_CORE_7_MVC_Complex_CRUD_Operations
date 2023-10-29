namespace Learn_ASP.NET_CRUD.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BackpackId { get; set; }
        public Backpack? Backpack { get; set; }
        public ICollection<Weapon>? Weapons { get; set; }
        public ICollection<Faction>? Factions { get; set;}
    }
}
