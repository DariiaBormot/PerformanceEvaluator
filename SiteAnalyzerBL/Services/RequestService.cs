using HtmlAgilityPack;
using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Services
{
    public class RequestService : IRequestService
    {
        public IEnumerable<PageBL> MeasureResponseTime(IEnumerable<PageBL> pages)
        {
            List<PageBL> result = new List<PageBL>();

            foreach (var page in pages)
            {
                result.Add(SendRequest(page));
            }

            return result;
        }


        private PageBL SendRequest(PageBL page)
        {
            try
            {

                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                var reqest = (HttpWebRequest)WebRequest.Create(page.Path);

                var responce = (HttpWebResponse)reqest.GetResponse();

                stopwatch.Stop();

                page.ResponseTime = stopwatch.Elapsed.Milliseconds;

                return page;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
