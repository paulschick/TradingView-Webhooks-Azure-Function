using System;
using System.Threading.Tasks;
using CoinGecko.Clients;
using CoinGecko.Entities.Response.Simple;
using CoinGecko.Interfaces;

namespace TradingView.Services
{
    public class CoinGeckoService : ICoinGeckoService
    {
        private readonly ICoinGeckoClient _client;

        public CoinGeckoService()
        {
            _client = CoinGeckoClient.Instance;
        }

        private async Task<string> GetPrice(string id)
        {
            var vsCurrency = "usd";
            Price result = await _client.SimpleClient.GetSimplePrice(
                new[] {id}, new[] {vsCurrency});
            var price = result[id][vsCurrency]?.ToString();
            if (String.IsNullOrEmpty(price))
            {
                return "";
            }
            else
            {
                return price;
            }
        }

        public async Task<string> GetGeistPrice()
        {
            return await GetPrice("geist-finance");
        }

        public async Task<string> GetTombPrice()
        {
            return await GetPrice("tomb");
        }

        public async Task<string> GetFantomPrice()
        {
            return await GetPrice("fantom");
        }
    }
}