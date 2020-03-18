using AutoMapper;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Mapping
{    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Rushing, RushingResource>();
            //CreateMap<Product, ProductResource>();
        }
    }
}