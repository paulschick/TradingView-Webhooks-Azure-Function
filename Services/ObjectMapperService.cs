using System.Threading.Tasks;
using TradingView.Models;

namespace TradingView.Services
{
    public class ObjectMapperService : IObjectMapperService
    {
        public AlertResponse GetPriceResponse(string apiResponse)
        {
            string[] splitData = apiResponse.Split(":");
            return new AlertResponse
            {
                Exchange = splitData[0],
                Symbol = splitData[1],
                Datetime = $"{splitData[2]}:{splitData[3]}:{splitData[4]}",
                Price = float.Parse(splitData[5].Split("=")[1]).ToString("#.##"),
                Volume = float.Parse(splitData[6].Split("=")[1]).ToString("#.##")
            };
        }

        public async Task<AllPrices> GetAllPrices(string timestamp, ICoinGeckoService gecko)
        {
            var gPrice = await gecko.GetGeistPrice();
            var tPrice = await gecko.GetTombPrice();
            var fPrice = await gecko.GetFantomPrice();
            var tombFantom = float.Parse(tPrice) / float.Parse(fPrice);
            return new AllPrices()
            {
                Timestamp = timestamp,
                FantomPrice = fPrice,
                TombPrice = tPrice,
                GeistPrice = gPrice,
                TombFantomPrice = tombFantom.ToString("#.##"),
            };
        }
    }
}