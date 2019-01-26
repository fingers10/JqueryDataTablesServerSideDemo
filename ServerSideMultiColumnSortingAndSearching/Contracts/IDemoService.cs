using ServerSideMultiColumnSortingAndSearching.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideMultiColumnSortingAndSearching.Contracts
{
    public interface IDemoService
    {
        Task<Demo[]> GetDataAsync(DTParameters table);
    }
}
