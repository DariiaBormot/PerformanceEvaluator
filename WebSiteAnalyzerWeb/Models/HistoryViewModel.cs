using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteAnalyzerWeb.Models
{
    public class HistoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Min Response Time")]
        public int MinResponseTime { get; set; }
        [Display(Name = "Max Response Time")]
        public int MaxResponseTime { get; set; }
        public DateTime Date { get; set; }
        public string SiteURL { get; set; }
        public int SiteId { get; set; }
    }
}