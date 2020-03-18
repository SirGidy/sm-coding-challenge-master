using System;

namespace sm_coding_challenge.Domain.Models
{
    public class DownloadTracker
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int PollingInterval { get; set; }
        public int Week { get; set; }
        public string SportsName { get; set; }
        public string CompetitionName { get; set; }
        public string SeasonId { get; set; }
    }
}