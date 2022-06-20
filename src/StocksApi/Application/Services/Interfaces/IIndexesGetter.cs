using System.Collections.Generic;
using System.Threading.Tasks;

namespace StocksApi.Services.Application
{
    public interface IIndexesGetter
    {
        Task<IEnumerable<IndexesGetter.IndexInfo>> GetAsync(IEnumerable<string> tickers);
    }
}