using PublicApi.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicApi.Services.Interfaces
{
    public interface IStocksService
    {
        Task<IEnumerable<StockIndex>> GetStocksAsync();
        Task<IEnumerable<StockIndex>> GetStocksAsync(int take, string after);
    }
}
