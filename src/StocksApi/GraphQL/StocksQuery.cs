using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using StocksApi.Schema.Models;
using StocksApi.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace StocksApi.Schema.Queries
{
    public class StocksQuery
    {
        private const int DefaultPageSize = 10;
        private readonly IStocksService _stocksService;

        public StocksQuery(IStocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [UsePaging]
        public async Task<Connection<StockIndexModel>> GetIndexes(string after, int? first, int? last, string before)
        {
            var indexes = await _stocksService.GetStocksAsync();

            var result = indexes.Select(x => new StockIndexModel()
            {
                IndexName = x.IndexName,
                Hight = x.High,
                Last = x.Last,
                Time = x.Time
            });

            if (!string.IsNullOrEmpty(after))
            {
                result = result.SkipWhile(x => x.IndexName != after).Skip(1);
            }

            result = result.Take(first ?? DefaultPageSize);


            var edges = result.Select(user => new Edge<StockIndexModel>(user, user.IndexName))
                              .ToList();

            var hasNextPage = edges.Count <= DefaultPageSize;
            var hasPreviousPage = false;
            var pageInfo = new ConnectionPageInfo(hasNextPage, hasPreviousPage, startCursor: null, endCursor: null);

            var connection = new Connection<StockIndexModel>(edges, pageInfo, ct => ValueTask.FromResult(0));

            return connection;
        }
    }
}
