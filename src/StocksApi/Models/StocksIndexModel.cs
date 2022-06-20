using System;

namespace StocksApi.Schema.Models
{
    public class StockIndexModel
    {
        public String IndexName { get; set; }
        public decimal Last { get; set; }
        public decimal Hight { get; set; }
        public DateTime Time { get; set; }
    }
}
