using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace prjWebSpaceMent
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Code that runs on the application startup
            // Specify the connection string, which is used to open a database. 
            // It's supposed that you've already created the Comments database
            // within the App_Data folder.
            //    string conn = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString(
            //      Server.MapPath("~\\App_Data\\Comments.mdb"));
            //    DevExpress.Xpo.Metadata.XPDictionary dict =
            //    new DevExpress.Xpo.Metadata.ReflectionDictionary();
            //    // Initialize the XPO dictionary.
            //    dict.GetDataStoreSchema(typeof(Comment).Assembly);
            //    DevExpress.Xpo.DB.IDataStore store = DevExpress.Xpo.XpoDefault.GetConnectionProvider(conn,
            //        DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);
            //    DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.ThreadSafeDataLayer(dict, store);
            //    DevExpress.Xpo.XpoDefault.Session = null;
        }
    }
}
