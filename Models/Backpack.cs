namespace Learn_ASP.NET_CRUD.Models
{
    public class Backpack
    {
        public int Id { get; set; }
        public string Desciption { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}
