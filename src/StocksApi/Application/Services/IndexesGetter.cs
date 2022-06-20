using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YahooQuotesApi;

namespace StocksApi.Services.Application
{
    public class IndexesGetter : IIndexesGetter
    {
        public async Task<IEnumerable<IndexInfo>> GetAsync(IEnumerable<string> tickers)
        {
            YahooQuotes yahooQuotes = new YahooQuotesBuilder().Build();

            Dictionary<string, Security> securities = await yahooQuotes.GetAsync(tickers);

            var res = securities.Where(x => x.Value != null).Select(x =>
            new IndexInfo()
            {
                Name = x.Key,
                High = x.Value.RegularMarketDayHigh ?? Decimal.Zero,
                Current = x.Value.RegularMarketPrice ?? Decimal.Zero,
                Date = x.Value.RegularMarketTime.ToDateTimeUtc()
            }
            );

            return res;
        }

        public class IndexInfo
        {
            public string Name { get; set; }
            public decimal High { get; set; }
            public decimal Current { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
