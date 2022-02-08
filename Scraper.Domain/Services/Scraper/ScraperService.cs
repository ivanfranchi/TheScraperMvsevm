using Scraper.Domain.Services;
using Scraper.Domain.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Application.Services.Scraper
{
    public class ScraperService : IScraperService
    {
        public async Task<IEnumerable<string>> ScrapeMvsevmAsync(CancellationToken cancellationToken)
        {
            var urls = new List<string>();
            urls.Add("http://www.computinghistory.org.uk/pages/28568/Visiting/");

            var client = MotivatedHttpClient.MotivateClient();
            var message = MotivatedHttpClient.GetEnhancedMessage(urls[0]);
            var responseBody = await MotivatedHttpClient.GetMessage(client, message, cancellationToken);

            return FunctionsScripts.ReadData(responseBody);
        }

        public async Task<IEnumerable<int>> ScrapeAsync(
            string urlToScrape,
            string textToFind,
            CancellationToken cancellationToken)
        {
            var client = MotivatedHttpClient.MotivateClient();
            var message = MotivatedHttpClient.GetEnhancedMessage(urlToScrape);
            var responseBody = await MotivatedHttpClient.GetMessage(client, message, cancellationToken);

            return FunctionsScripts.ParseXml(responseBody, textToFind);
        }
    }
}
