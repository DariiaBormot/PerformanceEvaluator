using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Models
{
    public class PageBL
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int MinResponseTime { get; set; }
        public int MaxResponseTime { get; set; }

        public int SiteId { get; set; }
        public SiteBL Site { get; set; }
    }
}
