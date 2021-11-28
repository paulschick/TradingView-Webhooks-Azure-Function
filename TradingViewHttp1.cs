using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TradingView.Services;

namespace TradingView
{
    public class TradingViewHttp1
    {
        private readonly IBlobService _blobService;
        private readonly ICoinGeckoService _gecko;
        private readonly IObjectMapperService _objService;

        public TradingViewHttp1(IBlobService blobService, ICoinGeckoService gecko, IObjectMapperService objService)
        {
            this._blobService = blobService;
            this._gecko = gecko;
            this._objService = objService;
        }

        [FunctionName("TradingViewHttp1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            [Blob("crypto-function-data/test-csv.csv", Connection = "AzureWebJobsStorage")]
            BlobClient client,
            ILogger log)
        {
            var dataString = await _blobService.ParseRequestBody(req);

            log.LogInformation("Received alert from TradingView");
            log.LogInformation(dataString);

            var priceResponse = _objService.GetPriceResponse(dataString);

            log.LogInformation("Requesting all price data from CoinGecko API");

            var allPrices = await _objService.GetAllPrices(priceResponse.Datetime, _gecko);

            log.LogInformation("Alert Timestamp:");
            log.LogInformation(allPrices.Timestamp);
            log.LogInformation("Fantom Alert Price:");
            log.LogInformation(allPrices.FantomPrice);
            log.LogInformation("TOMB Price:");
            log.LogInformation(allPrices.TombPrice);
            log.LogInformation("TOMB/FTM Price:");
            log.LogInformation(allPrices.TombFantomPrice);
            log.LogInformation("Geist Price:");
            log.LogInformation(allPrices.GeistPrice);

            log.LogInformation("Updating blob");
            await DataUpdateService.UpdateCsvBlob(client, allPrices, _blobService);

            return new OkObjectResult(dataString);
        }
    }
}