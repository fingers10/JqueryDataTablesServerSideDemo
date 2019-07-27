using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Infrastructure;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<JqueryDataTablesPagedResults<Demo>> GetDataAsync(JqueryDataTablesParameters table)
        {
            IQueryable<DemoEntity> query = _context.Demos
                                                   .AsNoTracking()
                                                   .Include(x => x.DemoNestedLevelOne)
                                                   .ThenInclude(y => y.DemoNestedLevelTwo);

            query = new SearchOptionsProcessor<Demo,DemoEntity>().Apply(query,table.Columns);
            query = new SortOptionsProcessor<Demo,DemoEntity>().Apply(query,table);

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .ProjectTo<Demo>(_mappingConfiguration)
                .ToArrayAsync();

            return new JqueryDataTablesPagedResults<Demo> {
                Items = items,
                TotalSize = size
            };
        }
    }
}
