using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using TradingView.Models;

namespace TradingView.Services
{
    public interface IBlobService
    {
        public Task<string> ParseRequestBody(HttpRequest req);
        public Task UploadCsvBlob(BlobClient client, List<AllPrices> allPrices);
        public Task<List<AllPrices>> DownloadCsvBlob(BlobClient client);
    }
}