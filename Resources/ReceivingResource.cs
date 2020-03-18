using System.ComponentModel.DataAnnotations;

namespace sm_coding_challenge.Resources
{
    public class ReceivingResource : BaseResource
    {
        [Display(Name = "yds")]
        public int Yds { get; set; }
        [Display(Name = "tds")]
        public int Tds { get; set; }
        [Display(Name = "rec")]
        public int Rec { get; set; }
    }
}