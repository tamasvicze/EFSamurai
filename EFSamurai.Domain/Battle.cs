using System;
using System.Collections.Generic;

namespace EFSamurai.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public Samurai Name { get; set; }
        public string Description { get; set; }
        public bool IsBrutal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private ICollection<SamuraiBattle> SamuraiBattles;
        public BattleLog BattleLog { get; set; }
    }
}