using System;
using System.IO;

namespace DXWebApplication1 {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
          
            if (Session["user_id"] != null && Session["user_role"] != null)
            {
                Response.Redirect("~/HomePage.aspx", false);

            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }
    }
}