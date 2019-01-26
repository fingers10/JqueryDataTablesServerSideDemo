using AutoMapper;
using ServerSideMultiColumnSortingAndSearching.Models;

namespace ServerSideMultiColumnSortingAndSearching.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DemoEntity, Demo>();
        }
    }
}
