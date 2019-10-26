using AspNetCoreServerSide.Models;
using AutoMapper;

namespace AspNetCoreServerSide.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DemoEntity, Demo>()
                .ForMember(dest => dest.Offices, opts => opts.MapFrom(src => src.Office))
                .ReverseMap();

            CreateMap<DemoNestedLevelOneEntity, DemoNestedLevelOne>()
                .ForMember(dest => dest.Extension, opts => opts.MapFrom(src => src.Extn))
                .ForMember(dest => dest.DemoNestedLevelTwos, opts => opts.MapFrom(src => src.DemoNestedLevelTwo))
                .ReverseMap();

            CreateMap<DemoNestedLevelTwoEntity, DemoNestedLevelTwo>()
                .ForMember(dest => dest.StartDates, opts => opts.MapFrom(src => src.StartDate))
                .ReverseMap();

            CreateMap<Demo, DemoExcel>();
        }
    }
}
