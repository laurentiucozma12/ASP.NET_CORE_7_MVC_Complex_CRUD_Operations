namespace Learn_ASP.NET_CRUD.Models
{
    public class Backpack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CharacterId { get; set; }
        public Character? Character { get; set; }
    }
}
