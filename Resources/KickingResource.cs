using System.ComponentModel.DataAnnotations;

namespace sm_coding_challenge.Resources
{
    public class KickingResource : BaseResource
    {
        [Display(Name = "fld_goals_made")]
        public int FldGoalsMade { get; set; }
        
        [Display(Name = "fld_goals_att")]
        public int FldGoalsAtt { get; set; }
        [Display(Name = "extra_pt_made")]
        public int ExtraPtMade { get; set; }
        [Display(Name = "extra_pt_att")]
        public int ExtraPtAtt { get; set; }
    }
}