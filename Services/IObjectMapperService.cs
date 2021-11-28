using System.Threading.Tasks;
using TradingView.Models;

namespace TradingView.Services
{
    public interface IObjectMapperService
    {
        public AlertResponse GetPriceResponse(string apiResponse);
        public Task<AllPrices> GetAllPrices(string timestamp, ICoinGeckoService gecko);
    }
}