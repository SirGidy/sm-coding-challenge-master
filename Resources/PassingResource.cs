using System.ComponentModel.DataAnnotations;

namespace sm_coding_challenge.Resources
{
    public class PassingResource : BaseResource
    {
        [Display(Name = "yds")]
        public int Yds { get; set; }
        [Display(Name = "att")]
        public int Att { get; set; }
        [Display(Name = "tds")]
        public int Tds { get; set; }
        [Display(Name = "cmp")]
        public int Cmp { get; set; }
        [Display(Name = "int")]
        public int Int { get; set; }
    }
}