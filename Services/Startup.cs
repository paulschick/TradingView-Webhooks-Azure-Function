using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(TradingView.Services.Startup))]

namespace TradingView.Services
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IBlobService>((s) => new BlobService());
            builder.Services.AddSingleton<IObjectMapperService>((s) => new ObjectMapperService());
            builder.Services.AddSingleton<ICoinGeckoService>((s) => new CoinGeckoService());
        }
    }
}