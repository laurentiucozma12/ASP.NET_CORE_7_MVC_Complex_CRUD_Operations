﻿namespace Learn_ASP.NET_CRUD.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Backpack Backpack { get; set; }
        public List<Weapon> Weapons { get; set;}
        public List<Faction> Factions { get; set;}
    }
}
