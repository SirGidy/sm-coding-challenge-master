using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sm_coding_challenge.Resources
{
    public abstract class BaseResource
    {
        [JsonPropertyName( "player_id")]
        public string PlayerId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }


    }
}