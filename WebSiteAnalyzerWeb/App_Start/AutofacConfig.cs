using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using SiteAnalyzerBL.Config;
using SiteAnalyzerBL.Interfaces;
using SiteAnalyzerBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteAnalyzerWeb.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                 new List<Profile>() { new AutoMapperProfileWeb(), new AutoMapperProfileBL() }));

            builder.Register(c => config.CreateMapper());

            builder.RegisterType<CrawlerService>().As<ICrawlerService>();
            builder.RegisterType<PageService>().As<IPageService>();
            builder.RegisterType<RequestService>().As<IRequestService>();
            builder.RegisterType<SitemapService>().As<ISitemapService>();
            builder.RegisterType<SiteSerivice>().As<ISiteSerivice>();


            builder.RegisterModule<AutofacConfigBL>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}