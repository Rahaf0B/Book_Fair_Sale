using BookFair.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private UserService _userService = UserService.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxLabelError.Visible = false;

        }

        protected async void FL_B_Log_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (TB_New_Password.Text == TB_Confairm_pass.Text)
                    {
                        ASPxLabelError.Visible = false;

                        string email = Request.QueryString["email"];

                        if (email != null)
                        {
                            string decodedEmail = Server.UrlDecode(email);
                            if (_userService.Validate_Email(email))
                                await _userService.ChangePassword(decodedEmail, TB_New_Password.Text);
                            Response.Redirect("~/Login.aspx");


                        }
                    }
                    else
                    {
                        ASPxLabelError.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", true);
        }

    }
}