using System.Text.Json.Serialization;

namespace sm_coding_challenge.Domain.Models
{
    
    public class Passing
    {
        public int Id { get; set; }
        [JsonPropertyName("player_id")]
        public string PlayerId {get;set;}
        [JsonPropertyName("entry_id")]
        public string EntryId { get; set; }
        [JsonPropertyName("yds")]
        public int Yds { get; set; }
        [JsonPropertyName("att")]
        public int Att { get; set; }
        [JsonPropertyName("tds")]
        public int Tds { get; set; }
        [JsonPropertyName("cmp")]
        public int Cmp { get; set; }
        [JsonPropertyName("int")]
        public int Int { get; set; }
    }
}