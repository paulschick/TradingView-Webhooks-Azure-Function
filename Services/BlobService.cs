using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using TradingView.Models;

namespace TradingView.Services
{
    public class BlobService : IBlobService
    {
        public async Task<string> ParseRequestBody(HttpRequest req)
        {
            using StreamReader sr = new StreamReader(req.Body);
            return await sr.ReadToEndAsync();
        }

        public async Task UploadCsvBlob(BlobClient client, List<AllPrices> allPrices)
        {
            await using var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            var csvWriter = new CsvWriter(sw, CultureInfo.InvariantCulture);
            await csvWriter.WriteRecordsAsync(allPrices);
            await csvWriter.FlushAsync();
            ms.Position = 0;
            await client.UploadAsync(ms, true);
        }

        public async Task<List<AllPrices>> DownloadCsvBlob(BlobClient client)
        {
            await using var ms = new MemoryStream();
            var sr = new StreamReader(ms);
            await client.DownloadToAsync(ms);
            var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture);
            var records = csvReader.GetRecordsAsync<AllPrices>();
            ms.Position = 0;
            var results = new List<AllPrices>();
            await foreach (var record in records)
            {
                results.Add(record);
            }

            return results;
        }
    }
}