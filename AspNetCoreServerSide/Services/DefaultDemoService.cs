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
    public class DefaultDemoService : IDemoService
    {
        private readonly Fingers10DbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultDemoService(Fingers10DbContext context, IConfigurationProvider mappingConfiguration)
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

            query = SearchOptionsProcessor<Demo, DemoEntity>.Apply(query, table.Columns);
            query = SortOptionsProcessor<Demo, DemoEntity>.Apply(query, table);

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .ProjectTo<Demo>(_mappingConfiguration)
                .ToArrayAsync();

            return new JqueryDataTablesPagedResults<Demo>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<Demo> GetDataByIdAsync(int id)
        {
            var item = await _context.Demos.AsNoTracking()
                                           .Include(x => x.DemoNestedLevelOne)
                                           .ThenInclude(y => y.DemoNestedLevelTwo)
                                           .SingleOrDefaultAsync(x => x.Id.Equals(id));

            return _mappingConfiguration.CreateMapper().Map<Demo>(item);
        }

        public async Task CreateDataAsync(Demo demo)
        {
            var entity = _mappingConfiguration.CreateMapper().Map<DemoEntity>(demo);

            await _context.Demos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDataAsync(Demo demo)
        {
            var entity = await _context.Demos.AsNoTracking()
                                           .Include(x => x.DemoNestedLevelOne)
                                           .ThenInclude(y => y.DemoNestedLevelTwo)
                                           .SingleOrDefaultAsync(x => x.Id.Equals(demo.Id));

            entity = _mappingConfiguration.CreateMapper().Map(demo, entity);

            _context.Demos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDataAsync(int id)
        {
            var item = await _context.Demos.FindAsync(id);

            _context.Demos.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
