using AutoMapper;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Mapping
{    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Rushing, RushingResource>();
            CreateMap<RushingResource,Rushing>();
            CreateMap<Kicking, KickingResource>();
            CreateMap<KickingResource,Kicking >();
            CreateMap<Receiving,ReceivingResource >();
            CreateMap<ReceivingResource,Receiving >();
            CreateMap<PassingResource,Passing >();
            CreateMap<Passing,PassingResource >();
            
            //CreateMap<Product, ProductResource>();
        }
    }
}