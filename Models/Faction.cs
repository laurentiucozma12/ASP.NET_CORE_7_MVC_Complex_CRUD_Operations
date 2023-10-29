namespace Learn_ASP.NET_CRUD.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Character>? Characters { get; set; }
    }
}
