using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteAnalyzerWeb.Models
{
    public class WebPageViewModel
    {
        public string Path { get; set; }
        public int MinResponseTime { get; set; }
        public int MaxResponseTime { get; set; }
    }
}