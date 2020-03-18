using System.ComponentModel.DataAnnotations;

namespace sm_coding_challenge.Resources
{
    public abstract class BaseResource
    {
        [Display(Name = "player_id")]
        public string PlayerId { get; set; }

        [Display(Name = "name")]
        public string Name { get; set; }

        [Display(Name = "position")]
        public string Position { get; set; }

    }
}