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
        }
        public int Id { get; set; }
        public string Url { get; set; }

        public IEnumerable<PageBL> Pages { get; set; }
    }
}
