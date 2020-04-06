using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Resources
{
    public class PlayerResource : BaseResource
    {
        
        public IEnumerable<RushingResource> rushing  {get; set;}
        public IEnumerable<PassingResource> passing {get; set;}
        public IEnumerable<ReceivingResource> receiving {get; set;}
        public IEnumerable<KickingResource> kicking {get; set;}
    }
}