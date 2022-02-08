using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper.Application.Services.Scraper
{
    public interface IScraperService
    {
        Task<IEnumerable<int>> ScrapeAsync(
            string urlToScrape,
            string textToFind,
            CancellationToken cancellationToken);

        Task<IEnumerable<string>> ScrapeMvsevmAsync(
            CancellationToken cancellationToken);
    }
}
