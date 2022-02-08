using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace Scraper.Domain.Utils
{
    public class FunctionsScripts
    {
        internal static IEnumerable<int> ParseXml(string xml, string textToFind)
        {
            //Tried with xpath
            // //div[@id="search"][1]/div[1]/div[1]/div/div[1]/div[1]/div[1]/a/@href
            // but the tags change and couldn't get to a minimum working solution

            var result = new List<int>();
            var document = new HtmlDocument();
            document.LoadHtml(xml);

            HtmlNode root = document.DocumentNode;
            var rows = document.DocumentNode
                .SelectNodes("//body//text()")
                .Select(node => node.InnerText);

            var counter = 1;
            var goodRows = rows.Where(x => x.ToLower().StartsWith("www.")).Distinct().Skip(4);
            foreach (var line in goodRows)
            {
                if (line.ToLower().Contains(textToFind.ToLower()))
                {
                    result.Add(counter);
                }
                counter++;
            }

            if (result.Count == 0)
            {
                result.Add(0);
                return result;
            }
            else
            {
                return result;
            }
        }

        internal static IEnumerable<string> ReadData(string urls)
        {



            throw new System.NotImplementedException();
        }
    }
}
