using System.Threading.Tasks;
using Azure.Storage.Blobs;
using TradingView.Models;

namespace TradingView.Services
{
    public static class DataUpdateService
    {
        public static async Task UpdateCsvBlob(BlobClient client, AllPrices prices, IBlobService service)
        {
            var allPrices = await service.DownloadCsvBlob(client);
            allPrices.Add(prices);
            await service.UploadCsvBlob(client, allPrices);
        }
    }
}