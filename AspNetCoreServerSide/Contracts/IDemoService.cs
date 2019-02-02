using AspNetCoreServerSide.Models;
using System.Threading.Tasks;
using AspNetCoreWeb.Models;

namespace AspNetCoreServerSide.Contracts
{
    public interface IDemoService
    {
        Task<Demo[]> GetDataAsync(DTParameters table);
    }
}
