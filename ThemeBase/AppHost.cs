using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ServiceApi;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Razor;
using ServiceStack.OrmLite.SqlServer;

namespace ThemeBase
{
    public class AppHost :AppHostBase 
    {
        public AppHost()
            : base("ThemeBase", typeof(TestService).Assembly)
        {
            
        }
        public override void Configure(Funq.Container container)
        {
            Plugins.Add(new RazorFormat());

            SetConfig(new HostConfig { AppendUtf8CharsetOnContentTypes = new HashSet<string> { MimeTypes.Html }, AllowJsonpRequests = true, AllowFileExtensions = { "json" } });

            var conString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
            var conFactory = new OrmLiteConnectionFactory(conString, SqlServerOrmLiteDialectProvider.Instance, true);
            container.Register<IDbConnectionFactory>(c => conFactory);

       
          

        }
    }
}