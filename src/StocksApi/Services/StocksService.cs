using Microsoft.Extensions.Caching.Memory;
using StocksApi.Services.Application;
using StocksApi.Services.Entities;
using StocksApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksApi.Services
{
    public class StocksService : IStocksService
    {
        private static TimeSpan CacheTtl = TimeSpan.FromSeconds(60);
        private static string CacheKey = "tickers_stocks";

        private readonly IIndexesGetter _indexGetter;
        private readonly IMemoryCache _cache;

        public StocksService(IIndexesGetter indexGetter, IMemoryCache cache)
        {
            _indexGetter = indexGetter;
            _cache = cache;
        }

        public async Task<IEnumerable<StockIndex>> GetStocksAsync()
        {
            if (!_cache.TryGetValue<IEnumerable<StockIndex>>(CacheKey, out var result))
            {
                await InvalidateCacheAsync();
            }

            result = _cache.Get<IEnumerable<StockIndex>>(CacheKey);

            return result;
        }

        private async Task InvalidateCacheAsync()
        {
            var tickers = TickersHelper.GetAllTickers();
            var data = await _indexGetter.GetAsync(tickers);
            var result = data.Select(x => new StockIndex
            {
                IndexName = x.Name,
                High = x.High,
                Last = x.Current,
                Time = x.Date
            });

            _cache.Set(CacheKey, result.ToArray(), DateTimeOffset.UtcNow + CacheTtl);
        }
    }
}
