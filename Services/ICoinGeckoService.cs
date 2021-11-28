using System.Threading.Tasks;
using CoinGecko.Interfaces;

namespace TradingView.Services
{
    public interface ICoinGeckoService
    {
        public Task<string> GetGeistPrice();
        public Task<string> GetTombPrice();
        public Task<string> GetFantomPrice();
    }
}