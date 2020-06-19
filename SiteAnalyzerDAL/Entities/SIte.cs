using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerDAL.Entities
{
    public class Site
    {
        public Site()
        {
            Pages = new List<Page>();
            Histories = new List<History>();
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public int MinResponseTime { get; set; }
        public int MaxResponseTime { get; set; }

        public virtual ICollection<Page> Pages { get; set; } 
        public virtual ICollection<History> Histories { get; set; }
    }
}
