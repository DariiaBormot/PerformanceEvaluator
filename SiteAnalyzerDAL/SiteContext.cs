using SiteAnalyzerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAnalyzerDAL
{
    public class SiteContext : DbContext 
    {
        public SiteContext()
        { }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
