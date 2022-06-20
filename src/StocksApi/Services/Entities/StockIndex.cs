using System;

namespace StocksApi.Services.Entities
{
    public class StockIndex
    {
        public String IndexName { get; set; }
        public decimal Last { get; set; }
        public decimal High { get; set; }
        public DateTime Time { get; set; }
    }
}
