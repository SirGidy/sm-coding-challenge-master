using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sm_coding_challenge.Domain.Models
{
    
    public class Rushing
    {
        public int Id { get; set; }
         [JsonPropertyName("player_id")]
        public string PlayerId {get;set;}
        [JsonPropertyName("entry_id")]
        public string EntryId { get; set; }
        public int Yds { get; set; }
        public int Att { get; set; }
        public int Tds { get; set; }
        public int Fum { get; set; }
    }
}