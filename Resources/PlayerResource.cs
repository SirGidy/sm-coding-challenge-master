using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sm_coding_challenge.Domain.Models;

namespace sm_coding_challenge.Resources
{
    public class PlayerResource : BaseResource
    {
        
        public IEnumerable<Rushing> rushing  {get; set;}
        public IEnumerable<Passing> passing {get; set;}
        public IEnumerable<Receiving> receiving {get; set;}
        public IEnumerable<Kicking> kicking {get; set;}
    }
}