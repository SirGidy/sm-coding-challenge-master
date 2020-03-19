using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sm_coding_challenge.Resources
{
    public class ReceivingResource : BaseResource
    {
        [JsonPropertyName("yds")]
        public int Yds { get; set; }
        [JsonPropertyName("tds")]
        public int Tds { get; set; }
        [JsonPropertyName("rec")]
        public int Rec { get; set; }
        [JsonPropertyName("entry_id")]
        public string EntryId { get; set; }
    }
}