using HtmlAgilityPack;
using SiteAnalyzerBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Services
{
    public class CrawlerService : ICrawlerService
    {
        private readonly HtmlWeb _htmlWeb;
        public CrawlerService()
        {
            _htmlWeb = new HtmlWeb();
        }

        public IEnumerable<string> GetPageLinks(string url)
        {
            HtmlDocument document = _htmlWeb.Load(url);

            List<string> mainLinks = new List<string>();

            var linkNodes = document.DocumentNode.SelectNodes("//a[@href]");

            if (linkNodes != null)
            {
                foreach (HtmlNode link in linkNodes)
                {
                    var href = link.Attributes["href"].Value;

                    var result = ValidateURL(href);

                    mainLinks.Add(result);

                }
            }

            return mainLinks;
        }

        private string ValidateURL(string url)
        {
            string str = string.Empty;

            if (url.Length > 1)
            {
                str = url.Substring(url.Length - 2, 2);

                if (str == "/#")
                {
                    url = url.Remove(url.Length - 2);
                    return url;
                }
            }

            str = url.Substring(url.Length - 1, 1);
            if (str == "/" || str == "#")
            {
                url = url.Remove(url.Length - 1);
                return url;
            }

            return url;
        }


    }
}
