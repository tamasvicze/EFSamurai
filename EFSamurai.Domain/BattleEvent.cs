namespace EFSamurai.Domain
{
    public class BattleEvent
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int BattleLogId { get; set; }
        public BattleLog BattleLog { get; set; }

    }
}