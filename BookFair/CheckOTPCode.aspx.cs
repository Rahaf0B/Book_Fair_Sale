using BookFair.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class CheckOTPCode : System.Web.UI.Page
    {
        private UserService _userService = UserService.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {

            ASPxLabelError.Visible = false;


        }

        protected async void ASPxButtonCheckCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    string email = Request.QueryString["email"];

                    if (email != null)
                    {
                        string decodedEmail = Server.UrlDecode(email);
                        if (_userService.Validate_Email(email))
                        {
                            string code = ASPxInputCode.Text;
                            bool result = await _userService.Check_OTP_Code(code, decodedEmail);
                            if (result)
                            {
                                ASPxLabelError.Visible = false;
                                string encodedEmail = Server.UrlEncode(decodedEmail);
                                Response.Redirect("~/ChangePassword.aspx?email=" + encodedEmail);

                            }
                            else
                            {
                                ASPxLabelError.Visible = true;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ASPxLabelError.Visible = true;

            }
        }
        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", true);
        }

    }


}

