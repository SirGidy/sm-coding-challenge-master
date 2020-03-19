using System.Collections.Generic;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Domain.Services.Communication
{
    public class LatestPlayerResponse 
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public IList<ReceivingResource> receiving {get; set;}
        public IList<RushingResource> rushing  {get; set;}
     

        public LatestPlayerResponse(IList<ReceivingResource> receivingresource,IList<RushingResource> rushingresource)
        {
            Success = true;
            receiving = receivingresource;
            rushing = rushingresource;
        }

        public LatestPlayerResponse(string message)
        {
            Success = false;
            Message = message;
            
        }
    }
}