using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sm_coding_challenge.Resources
{
    public class RushingResource : BaseResource
    {
        [JsonPropertyName("yds")]
        public int Yds { get; set; }
        [JsonPropertyName( "att")]
        public int Att { get; set; }
        [JsonPropertyName("tds")]
        public int Tds { get; set; }
        [JsonPropertyName( "fum")]
        public int Fum { get; set; }
       [JsonPropertyName("entry_id")]
        public string EntryId { get; set; }
    }
}