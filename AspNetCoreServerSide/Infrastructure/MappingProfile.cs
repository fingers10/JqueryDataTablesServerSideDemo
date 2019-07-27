using AspNetCoreServerSide.Models;
using AutoMapper;

namespace AspNetCoreServerSide.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DemoEntity, Demo>();

            CreateMap<DemoNestedLevelOneEntity, DemoNestedLevelOne>();

            CreateMap<DemoNestedLevelTwoEntity, DemoNestedLevelTwo>();
        }
    }
}
