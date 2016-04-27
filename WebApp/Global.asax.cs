using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            using (var context = new MultiTenantContext())
            {
                if (!context.Speakers.Any())
                {
                    context.Speakers.Add(new Speaker()
                    {
                        LastName = Guid.NewGuid().ToString("N")
                    });
                    context.Sessions.Add(new Session()
                    {
                        Title = Guid.NewGuid().ToString("N")
                    });
                    context.SaveChanges();
                }
            }


            using (var context = new MultiTenantContext())
            {
                if (!context.Tenants.Any())
                {
                    var tenants = new List<Tenant>
                    {
                        new Tenant
                        {
                            Name = "SVCC",
                            DomainName = "www.siliconvalley-codecamp.com",
                            Id = 1,
                            Default = true
                        },
                        new Tenant()
                        {
                            Name = "ANGU",
                            DomainName = "angularu.com",
                            Id = 3,
                            Default = false
                        },
                        new Tenant()
                        {
                            Name = "CSSC",
                            DomainName = "codestarssummit.com",
                            Id = 2,
                            Default = false
                        }

                    };
                    context.Tenants.AddRange(tenants);
                    context.SaveChanges();
                }
            }

        }
    }
}
