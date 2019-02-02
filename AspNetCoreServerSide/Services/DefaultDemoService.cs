using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Infrastructure;
using AspNetCoreServerSide.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWeb.Infrastructure;
using AspNetCoreWeb.Models;

namespace AspNetCoreServerSide.Services
{
    public class DefaultDemoService:IDemoService
    {
        private readonly Fingers10DbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultDemoService(Fingers10DbContext context,IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<Demo[]> GetDataAsync(DTParameters table)
        {
            IQueryable<DemoEntity> query = _context.Demos;
            query = new SearchOptionsProcessor<Demo,DemoEntity>().Apply(query,table.Columns);
            query = new SortOptionsProcessor<Demo,DemoEntity>().Apply(query,table);

            var items = await query
                .AsNoTracking()
                .Skip(table.Start - 1 * table.Length)
                .Take(table.Length)
                .ProjectTo<Demo>(_mappingConfiguration)
                .ToArrayAsync();

            return items;
        }
    }
}
