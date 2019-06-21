using AspNetCoreServerSide.Contracts;
using AspNetCoreServerSide.Helpers;
using AspNetCoreServerSide.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using JqueryDataTables.ServerSide.AspNetCoreWeb.ActionResults;
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

        public async Task<JqueryDataTablesResult<Demo>> GetDataAsync(JqueryDataTablesParameters table)
        {
			return await JqueryDataTableHelpers.GetJqueryDataTablesResultAsync<Demo, DemoEntity>(table, _context.Demos, _mappingConfiguration);
        }

		public async Task<JqueryDataTablesExcelResult<Demo>> GetExcelDataAsync(JqueryDataTablesParameters table, bool convertAllData = false)
        {
			return await JqueryDataTableHelpers.GetJqueryDataTablesExcelResultAsync<Demo, DemoEntity>(table, _context.Demos, _mappingConfiguration, convertAllData, "Demo Sheet Name", "Fingers10");
        }
    }
}
