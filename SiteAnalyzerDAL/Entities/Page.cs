using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerDAL.Entities
{
    public class Page
    {
        public int Id { get; set; }
        public string Path { get; set; } 
        public int MinResponseTime { get; set; }
        public int MaxResponseTime { get; set; } 

        public int SiteId { get; set; } 
        public virtual Site Site { get; set; }
    }
}
