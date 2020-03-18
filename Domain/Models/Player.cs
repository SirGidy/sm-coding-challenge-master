using System.Runtime.Serialization;

namespace sm_coding_challenge.Domain.Models
{
    [DataContract]
    public class Player
    {
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public Rushing rushing { get; set; }
        public Passing passing { get; set; }
        public Receiving receiving { get; set; }
        public Kicking kicking {get;set;}
    }
}

