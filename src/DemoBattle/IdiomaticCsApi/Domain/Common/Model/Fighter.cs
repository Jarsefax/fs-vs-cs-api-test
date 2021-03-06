﻿namespace IdiomaticCsApi.Domain.Common.Model
{
    public abstract class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Power { get; set; }
        public bool HasBeenDefeated { get; set; }
    }
}