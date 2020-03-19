using System.Text.Json.Serialization;

namespace sm_coding_challenge.Domain.Models
{
    
    public class Kicking
    {
        public int Id { get; set; }
        [JsonPropertyName("player_id")]
        public string PlayerId {get;set;}
        [JsonPropertyName("entry_id")]
        public string EntryId { get; set; }
        [JsonPropertyName("fld_goals_made")]
        public int FldGoalsMade { get; set; }
        [JsonPropertyName("fld_goals_att")]
        public int FldGoalsAtt { get; set; }
        [JsonPropertyName("extra_pt_made")]
        public int ExtraPtMade { get; set; }
        [JsonPropertyName("extra_pt_att")]
        public int ExtraPtAtt { get; set; }
        [JsonPropertyName("player")]
        public Player Player { get; set; }

    }
}