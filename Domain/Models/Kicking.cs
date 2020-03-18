namespace sm_coding_challenge.Domain.Models
{
    
    public class Kicking
    {
        public int Id { get; set; }
        public string PlayerId {get;set;}
        public string EntryId { get; set; }
        public int FldGoalsMade { get; set; }
        public int FldGoalsAtt { get; set; }
        public int ExtraPtMade { get; set; }
        public int ExtraPtAtt { get; set; }
        public Player Player { get; set; }

    }
}