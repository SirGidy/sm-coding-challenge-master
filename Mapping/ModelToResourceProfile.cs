using AutoMapper;
using sm_coding_challenge.Domain.Models;
using sm_coding_challenge.Resources;

namespace sm_coding_challenge.Mapping
{    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Rushing, RushingResource>().ReverseMap();
            CreateMap<Kicking, KickingResource>().ReverseMap();
            CreateMap<Receiving,ReceivingResource >().ReverseMap();
            CreateMap<PassingResource,Passing >().ReverseMap();

            //CreateMap<Product, ProductResource>();

            //     .ForMember(dest =>
            //     dest.FName,
            //     opt => opt.MapFrom(src => src.FirstName))
            // .ForMember(dest =>
            //     dest.LName,
            //     opt => opt.MapFrom(src => src.LastName))
        }
    }
}