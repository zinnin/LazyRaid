﻿namespace LazyRaid.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Specialization CurrentSpecialization { get; set; }
        public OC<Specialization> AvailableSpecializations { get; set; }
    }
}
