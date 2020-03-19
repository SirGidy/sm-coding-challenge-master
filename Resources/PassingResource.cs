using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sm_coding_challenge.Resources
{
    public class PassingResource : BaseResource
    {
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