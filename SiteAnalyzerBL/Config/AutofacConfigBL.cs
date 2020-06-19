using Autofac;
using SiteAnalyzerDAL;
using SiteAnalyzerDAL.Interfaces;
using SiteAnalyzerDAL.Repositories;


namespace SiteAnalyzerBL.Config
{
    public class AutofacConfigBL : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiteContext>().InstancePerRequest();
            builder.RegisterType<PageRepository>().As<IPageRepository>();
            builder.RegisterType<SiteRepository>().As<ISiteRepository>();
            builder.RegisterType<HistoryRepository>().As<IHistoryRepository>();
        }
    }
}
