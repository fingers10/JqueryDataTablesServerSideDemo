using AspNetCoreServerSide.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.Contracts
{
    public interface IDemoService
    {
        Task<Demo[]> GetDataAsync(DTParameters table);
    }
}
