using AspNetCoreServerSide.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.Contracts
{
    public interface IDemoService
    {
        Task<JqueryDataTablesPagedResults<Demo>> GetDataAsync(JqueryDataTablesParameters table);
        Task<Demo> GetDataByIdAsync(int id);
        Task CreateDataAsync(Demo demo);
        Task UpdateDataAsync(Demo demo);
        Task DeleteDataAsync(int id);
    }
}
