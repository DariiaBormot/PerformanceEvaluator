using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAnalyzerWeb.Models
{
    public class WebSiteViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Enter URL to analyze")]
        public string Url { get; set; }
        public int MaxResponseTime { get; set; }
        public int MinResponseTime { get; set; } 

        public IEnumerable<WebPageViewModel> Pages { get; set; }
    }
}