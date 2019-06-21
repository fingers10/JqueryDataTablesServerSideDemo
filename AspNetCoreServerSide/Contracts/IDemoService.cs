using AspNetCoreServerSide.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.ActionResults;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.Contracts
{
    public interface IDemoService
    {
        Task<JqueryDataTablesResult<Demo>> GetDataAsync(JqueryDataTablesParameters table);
		Task<JqueryDataTablesExcelResult<Demo>> GetExcelDataAsync(JqueryDataTablesParameters table, bool convertAllData = false);
    }
}
