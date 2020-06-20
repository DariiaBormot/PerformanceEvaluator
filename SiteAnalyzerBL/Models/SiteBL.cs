using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Models
{
    public class SiteBL
    {
        public SiteBL()
        {
            Pages = new List<PageBL>();
            Histories = new List<HistoryBL>();
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public int MinResponseTime { get; set; }
        public int MaxResponseTime { get; set; }

        public virtual IEnumerable<PageBL> Pages { get; set; }
        public virtual IEnumerable<HistoryBL> Histories { get; set; }
    }
}
