namespace sm_coding_challenge.Domain.Models
{
    
    public class Receiving
    {
        public int Id { get; set; }
        public string PlayerId {get;set;}
        public string EntryId { get; set; }
        public int Yds { get; set; }
        public int Tds { get; set; }
        public int Rec { get; set; }
    }
}