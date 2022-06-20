using System;

namespace PublicApi.Services.Entities
{
    public class StockIndex
    {
        public String IndexName { get; set; }
        public decimal Last { get; set; }
        public decimal Hight { get; set; }
        public DateTime Time { get; set; }
    }
}
