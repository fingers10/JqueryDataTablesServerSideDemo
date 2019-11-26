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
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Position, opts => opts.MapFrom(src => EnumHelper<Position>.GetDisplayValue(src.Position)))
                .ForMember(dest => dest.Offices, opts => opts.MapFrom(src => src.Office))
                .ReverseMap()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => SplitHelper.Split(src.Name, ' ', 0)))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => SplitHelper.Split(src.Name, ' ', 1)));

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
