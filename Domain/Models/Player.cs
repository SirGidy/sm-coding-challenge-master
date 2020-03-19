using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace sm_coding_challenge.Domain.Models
{
    [DataContract]
    public class Player
    {
        public int Id { get; set; }
        [JsonPropertyName("player_id")]
        public string PlayerId { get; set; 
        }
        public string Name { get; set; }
        public string Position { get; set; }
        public IList<Rushing> Rushings { get; set; } = new List<Rushing>();
        public IList<Passing> Passing { get; set; } = new List<Passing>();
        public IList<Receiving> Receivings { get; set; } = new List<Receiving>();
        public IList<Kicking> Kickings { get; set; } = new List<Kicking>();       
    }
}

