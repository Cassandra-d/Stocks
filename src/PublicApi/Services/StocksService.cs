using PublicApi.Services.Entities;
using PublicApi.Services.Interfaces;
using StocksApiClient;
using StrawberryShake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicApi.Services
{
    public class StocksService : IStocksService
    {
        private const int MaxPageSize = 10;
        private readonly IStocksApiClient _stocksApiClient;

        public StocksService(IStocksApiClient stocksApiClient)
        {
            _stocksApiClient = stocksApiClient;
        }

        public async Task<IEnumerable<StockIndex>> GetStocksAsync()
        {
            var res = await _stocksApiClient.GetIndexes.ExecuteAsync(after: null, first: MaxPageSize, cancellationToken: default);

            try
            {
                res.EnsureNoErrors();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't fetch stocks", ex);
            }

            return res.Data.Indexes.Nodes.Select(StockIndexMap);
        }

        public async Task<IEnumerable<StockIndex>> GetStocksAsync(int take, string after)
        {
            var pageSize = Math.Min(take, MaxPageSize);
            var res = await _stocksApiClient.GetIndexes.ExecuteAsync(after: after, first: pageSize, cancellationToken: default);

            try
            {
                res.EnsureNoErrors();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't fetch stocks", ex);
            }

            return res.Data.Indexes.Nodes.Select(StockIndexMap);
        }

        private static StockIndex StockIndexMap(IGetIndexes_Indexes_Nodes x) => new StockIndex
        {
            IndexName = x.IndexName,
            Hight = x.Hight,
            Last = x.Hight,
            Time = x.Time.UtcDateTime
        };
    }
}
