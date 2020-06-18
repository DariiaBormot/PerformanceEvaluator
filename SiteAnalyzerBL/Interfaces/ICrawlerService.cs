using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerBL.Interfaces
{
    public interface ICrawlerService
    {
        IEnumerable<string> GetPageLinks(string url);
    }
}
