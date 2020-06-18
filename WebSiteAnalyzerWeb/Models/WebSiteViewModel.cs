using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAnalyzerWeb.Models
{
    public class WebSiteViewModel
    {
        [Display(Name = "Enter URL to analyze")]
        public string Url { get; set; }

        public IEnumerable<WebPageViewModel> Pages { get; set; }
    }
}