using System.Collections.Generic;
using System.Runtime.Serialization;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Models
{
    [DataContract]
    public class DataResponseModel
    {
        [DataMember(Name = "week")]
        public string Week { get; set; }

        [DataMember(Name = "sportName")]
        public string SportName { get; set; }

        [DataMember(Name = "competitionName")]
        public string CompetitionName { get; set; }

        [DataMember(Name = "seasonID")]
        public string SeasonId { get; set; }

        [DataMember(Name = "rushing")]
        public List<RushingResource> Rushing { get; set; }

        [DataMember(Name = "passing")]
        public List<PassingResource> Passing { get; set; }

        [DataMember(Name = "receiving")]
        public List<ReceivingResource> Receiving { get; set; }

        [DataMember(Name = "kicking")]
        public List<KickingResource> Kicking { get; set; }

        public DataResponseModel()
        {

        }
    }
}

