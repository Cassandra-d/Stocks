using Microsoft.AspNetCore.Mvc;
using PublicApi.Services.Entities;
using PublicApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicApi.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStocksService _stocksService;

        public StocksController(IStocksService stocksService)
        {
            _stocksService = stocksService;
        }
        
        [HttpGet("allStocks")]
        public async Task<IEnumerable<StockIndex>> GetAllStocks()
        {
            var result = await _stocksService.GetStocksAsync();
            return result;
        }

        [HttpGet("stocks")]
        public async Task<IEnumerable<StockIndex>> GetStocks(int take, string after)
        {
            var result = await _stocksService.GetStocksAsync(take, after);
            return result;
        }
    }
}
