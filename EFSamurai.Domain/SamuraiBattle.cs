using System.Reflection.Metadata;

namespace EFSamurai.Domain
{
    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
        public int BattleId { get; set; }
        public string BattleProperties { get; set; }
        public Battle Battle { get; set; } 
    }
}