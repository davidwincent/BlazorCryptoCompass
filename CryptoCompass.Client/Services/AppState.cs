using CryptoCompass.Shared;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoCompass.Client.Services
{
    public class AppState
    {
        public bool Loading { get; private set; }
        public BinanceTicker[] BinanceTickers { get; private set; }

        private readonly HttpClient http;

        public AppState(HttpClient http)
        {
            this.http = http;
            Loading = true;
            Console.WriteLine("'AppState' constructed.");
        }

        public async Task Init()
        {
            Console.WriteLine("'AppState.Init' started.");
            BinanceTickers = await http.GetJsonAsync<BinanceTicker[]>("binance/api/v1/ticker/24h.json");
            Loading = false;
            Console.WriteLine("'AppState.Init' ended.");
        }
    }
}
