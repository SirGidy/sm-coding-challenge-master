using System.ComponentModel.DataAnnotations;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Resources
{
    public class PlayerResource : BaseResource
    {
        
        public Rushing rushing  {get; set;}
        public Passing passing {get; set;}
        public Receiving receiving {get; set;}
        public Kicking kicking {get; set;}
    }
}