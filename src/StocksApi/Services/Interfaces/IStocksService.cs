using StocksApi.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StocksApi.Services.Interfaces
{
    public interface IStocksService
    {
        Task<IEnumerable<StockIndex>> GetStocksAsync();
    }
}
