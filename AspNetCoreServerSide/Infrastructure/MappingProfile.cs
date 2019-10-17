using AspNetCoreServerSide.Helpers;
using AspNetCoreServerSide.Models;
using AutoMapper;

namespace AspNetCoreServerSide.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DemoEntity, Demo>()
                .ForMember(dest => dest.Position, opts => opts.MapFrom(src => EnumHelper<Position>.GetDisplayValue(src.Position)))
                .ForMember(dest => dest.Offices, opts => opts.MapFrom(src => src.Office));

            CreateMap<DemoNestedLevelOneEntity, DemoNestedLevelOne>()
                .ForMember(dest => dest.Extension, opts => opts.MapFrom(src => src.Extn))
                .ForMember(dest => dest.DemoNestedLevelTwos, opts => opts.MapFrom(src => src.DemoNestedLevelTwo));

            CreateMap<DemoNestedLevelTwoEntity, DemoNestedLevelTwo>()
                .ForMember(dest => dest.StartDates, opts => opts.MapFrom(src => src.StartDate));

            CreateMap<Demo, DemoExcel>();
        }
    }
}
