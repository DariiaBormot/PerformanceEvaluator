using System;

namespace SiteAnalyzerBL.Models
{
    public class HistoryBL
    {
        public int Id { get; set; }
        public int MinResponseTime { get; set; }
        public int MaxResponseTime { get; set; }
        public DateTime Date { get; set; }
        public string SiteURL { get; set; }

        public virtual SiteBL Site { get; set; }
        public int SiteId { get; set; }
    }
}
