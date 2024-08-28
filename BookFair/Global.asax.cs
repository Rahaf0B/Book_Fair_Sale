using DevExpress.Xpo;
using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

using System.IO;
using BookFair.Models.BookFair;

namespace BookFair {
    public class Global_asax : System.Web.HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(Application_Error);
            DevExpress.Security.Resources.AccessSettings.DataResources.SetRules(
                DevExpress.Security.Resources.DirectoryAccessRule.Allow(Server.MapPath("~/Content")),
                DevExpress.Security.Resources.DirectoryAccessRule.Allow(Server.MapPath("~/utils")),

                DevExpress.Security.Resources.UrlAccessRule.Allow()
            );



            // Configure the connection string
            string CS = ConfigurationManager.ConnectionStrings["CDBN"].ConnectionString;
            IDisposable[] disposableObjects;
            // Set up the Data Layer
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                CS,
                XpoDefault.Dictionary,
              DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema,
                out disposableObjects);
            //Initialize a session and trigger schema creation
            using (Session session = new Session(XpoDefault.DataLayer))
            { session.UpdateSchemaAsync(); }

            DevExpress.Xpo.SimpleDataLayer.SuppressReentrancyAndThreadSafetyCheck = true;



        }

        void Application_End(object sender, EventArgs e) {
            // Code that runs on application shutdown
        }
    
        void Application_Error(object sender, EventArgs e) {
            // Code that runs when an unhandled error occurs
        }
    
        void Session_Start(object sender, EventArgs e) {
            // Code that runs when a new session is started
        }
    
        void Session_End(object sender, EventArgs e) {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }
    }
}