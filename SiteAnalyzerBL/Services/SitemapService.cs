﻿using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Models;
using System.Collections.Generic;

namespace SiteAnalyzerBL.Services
{
    public class SitemapService : ISitemapService
    {

        public IEnumerable<PageBL> GetPages(IEnumerable<string> paths, string url)
        {
            List<string> sitemapNodes = GetAbsoluteUrls(paths, url);

            List<PageBL> pages = new List<PageBL>();

            foreach (string sitemapNode in sitemapNodes)
            {
                pages.Add(new PageBL
                {
                    Path = sitemapNode
                });
            }

            return pages;
        }

        private List<string> GetAbsoluteUrls(IEnumerable<string> relativeLinks, string url)
        {
            var sitemapNodes = new List<string>();

            var host = CorrectURL(url);

            foreach (var link in relativeLinks)
            {
                if (IsValidPath(link))
                {
                    sitemapNodes.Add(host + link);
                }

            }

            return sitemapNodes;
        }

        private string CorrectURL(string url)
        {
            string lastSymbol = url.Substring(url.Length - 1, 1);

            if (lastSymbol == "/" || lastSymbol == "#")
            {
                url = url.Remove(url.Length - 1);
            }

            return url;
        }

        private bool IsValidPath(string path)
        {

            if (!path.StartsWith("http") && !path.StartsWith("www"))
            {
                return true;
            }

            return false;
        }

    }
}
