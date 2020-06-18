using HtmlAgilityPack;
using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

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

                Stopwatch stopWatch = new Stopwatch();
                //var document = new HtmlDocument();

                stopWatch.Start();

                HttpWebRequest reqest = (HttpWebRequest)WebRequest.Create(page.Path);
                HttpWebResponse responce = (HttpWebResponse)reqest.GetResponse();
                //document.Load(responce.GetResponseStream());

                stopWatch.Stop();

                page.MaxResponseTime = stopWatch.Elapsed.Milliseconds;
                page.MinResponseTime = stopWatch.Elapsed.Milliseconds;

                return page;

            }
            catch(Exception ex)
            {
                return null;
            }

        }

    }
}
