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
        }
        public int Id { get; set; }
        public string Url { get; set; } 

        public virtual ICollection<Page> Pages { get; set; } 
    }
}
