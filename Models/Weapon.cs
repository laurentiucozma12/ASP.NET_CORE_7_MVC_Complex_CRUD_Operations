﻿namespace Learn_ASP.NET_CRUD.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CharacterId { get; set; }
        public Character? Character { get; set; }
    }
}
