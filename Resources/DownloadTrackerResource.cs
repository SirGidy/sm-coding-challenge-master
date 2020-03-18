using System;
using System.ComponentModel.DataAnnotations;

namespace sm_coding_challenge.Resources
{
    public class DownloadTrackerResource
    {
        public DateTime TimeStamp { get; set; }
        public int PollingInterval { get; set; }
        public int Week { get; set; }
        public string SportsName { get; set; }
        public string CompetitionName { get; set; }
        public string SeasonId { get; set; }
    }
}