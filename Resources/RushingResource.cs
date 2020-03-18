using System.ComponentModel.DataAnnotations;

namespace sm_coding_challenge.Resources
{
    public class RushingResource : BaseResource
    {
        [Display(Name = "yds")]
        public int Yds { get; set; }
        [Display(Name = "att")]
        public int Att { get; set; }
        [Display(Name = "tds")]
        public int Tds { get; set; }
        [Display(Name = "fum")]
        public int Fum { get; set; }
    }
}