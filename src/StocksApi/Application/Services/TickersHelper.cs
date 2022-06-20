using System;
using System.Collections.Generic;

namespace StocksApi.Services.Application
{
    internal static class TickersHelper
    {
        private static Lazy<HashSet<string>> _tickers = new Lazy<HashSet<string>>(() => new HashSet<string>() {
 "MMM",
"ABBV",
"ALV",
"GOOG",
"AMZN",
"AMGN",
"ABI",
"AAPL",
"BHP",
"BA",
"BP",
"BATS",
"CVX",
"CSCO",
"C",
"KO",
"DD",
"XOM",
"FB",
"GE",
"GSK",
"HSBA",
"INTC",
"IBM",
"JNJ",
"JPM",
"MA",
"MCD",
"MRK",
"MSFT",
"NESN",
"NOVN",
"NVDA",
"ORCL",
"PEP",
"PFE",
"PM",
"PG",
"ROG",
"RY",
"RDSA",
"SMSN",
"SAN",
"SIE",
"TSM",
"TOT",
"V",
"WMT",
"DIS"
        }, isThreadSafe: true);

        public static IEnumerable<string> GetAllTickers() => _tickers.Value;
    }
}
